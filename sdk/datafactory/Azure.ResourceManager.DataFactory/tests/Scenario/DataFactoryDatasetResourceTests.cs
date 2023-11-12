// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Reflection;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryDatasetResourceTests : DataFactoryManagementTestBase
    {
        private string _accessKey;
        private string _linkedServiceName;
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        public DataFactoryDatasetResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgName = SessionRecording.GenerateAssetName("DataFactory-RG-");
            var storageAccountName = SessionRecording.GenerateAssetName("datafactory");
            if (Mode == RecordedTestMode.Playback)
            {
                _resourceGroupIdentifier = ResourceGroupResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName);
                _accessKey = "Sanitized";
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var subscription = await GlobalClient.GetDefaultSubscriptionAsync();
                    var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    _resourceGroupIdentifier = rgLro.Value.Data.Id;
                    _accessKey = await GetStorageAccountAccessKey(rgLro.Value, storageAccountName);
                }
            }
            await StopSessionRecordingAsync();
        }

        [TearDown]
        public async Task GlobalTearDown()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }
            try
            {
                using (Recording.DisableRecording())
                {
                    await foreach (var storageAccount in _resourceGroup.GetDataFactories().GetAllAsync())
                    {
                        await storageAccount.DeleteAsync(WaitUntil.Completed);
                    }
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        [TearDown]
        public async Task TestCaseDoneTearDown()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }
            try
            {
                using (Recording.DisableRecording())
                {
                    await foreach (var dataFactoryResource in _resourceGroup.GetDataFactories().GetAllAsync())
                    {
                        await dataFactoryResource.DeleteAsync(WaitUntil.Completed);
                    }
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDataset(DataFactoryResource dataFactory, string datasetName)
        {
            DataFactoryLinkedServiceReference linkedServiceReference = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, _linkedServiceName);
            DataFactoryDatasetProperties properties = new DataFactoryDatasetProperties(linkedServiceReference);
            DataFactoryDatasetData data = new DataFactoryDatasetData(properties);
            var dataset = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return dataset.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            var dataset = await CreateDefaultDataset(dataFactory, datasetName);
            Assert.IsNotNull(dataset);
            Assert.AreEqual(datasetName, dataset.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            await CreateDefaultDataset(dataFactory, datasetName);
            bool flag = await dataFactory.GetDataFactoryDatasets().ExistsAsync(datasetName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            await CreateDefaultDataset(dataFactory, datasetName);
            var dataset = await dataFactory.GetDataFactoryDatasets().GetAsync(datasetName);
            Assert.IsNotNull(dataset);
            Assert.AreEqual(datasetName, dataset.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            await CreateDefaultDataset(dataFactory, datasetName);
            var list = await dataFactory.GetDataFactoryDatasets().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            var dataset = await CreateDefaultDataset(dataFactory, datasetName);
            bool flag = await dataFactory.GetDataFactoryDatasets().ExistsAsync(datasetName);
            Assert.IsTrue(flag);

            await dataset.DeleteAsync(WaitUntil.Completed);
            flag = await dataFactory.GetDataFactoryDatasets().ExistsAsync(datasetName);
            Assert.IsFalse(flag);
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureBlobStorageLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureBlobStorageLinkedService()
            {
                ConnectionString = "DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net"
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureBlob()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureBlobStorageLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureBlobDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Structure = new List<DatasetDataElement>()
                {
                    new DatasetDataElement(){ ColumnName = "PartitionKey",ColumnType = "Guid"},
                    new DatasetDataElement(){ ColumnName = "RowKey",ColumnType = "String"},
                    new DatasetDataElement(){ ColumnName = "Timestamp",ColumnType = "String"},
                    new DatasetDataElement(){ ColumnName = "game_id",ColumnType = "String"},
                    new DatasetDataElement(){ ColumnName = "date",ColumnType = "Datetime"},
                },
                FolderPath = "\"MyContainer\\\\MySubFolder\\\\$Date\\\\$Time\\\\FileName$Date$Time\\\\{PartitionKey}\"",
                FileName = "testblobname",
                Format = new DatasetTextFormat()
                {
                    ColumnDelimiter = ",",
                    RowDelimiter = ";",
                    EscapeChar = "#",
                    NullValue = "\\N",
                    EncodingName = "UTF-8"
                },
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureDatabricksDeltaLakeLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureDatabricksDeltaLakeLinkedService("https://westeurope.azuredatabricks.net/")
            {
                ClusterId = "0714-063833-cleat653",
                AccessToken = new DataFactorySecretString("mykey")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureDatabricksDeltaLakeDataset()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureDatabricksDeltaLakeLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureDatabricksDeltaLakeDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "azuretable",
                Database = "default"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureTableStorageLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureTableStorageLinkedService()
            {
                ConnectionString = "DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net"
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureTableStorageLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "table$Date$Time") { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureSqlDatabaseLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureSqlDatabaseLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureSqlTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureSqlDatabaseLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TableName = "MyEncryptedTableName"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureSqlMILinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureSqlMILinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureSqlMITable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureSqlMILinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Schema = new List<DatasetSchemaDataElement>()
                {
                    new DatasetSchemaDataElement(){ SchemaColumnName = "dbo",SchemaColumnType="string"}
                },
                Table = "test",
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureSqlDWLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureSqlDWLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureSqlDWTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureSqlDWLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureSqlDWTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TableName = "MyEncryptedTableName"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSqlServerLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SqlServerLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SqlServerTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSqlServerLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SqlServerTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TableName = BinaryData.FromString("\"MyEncryptedTableName\"")
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_CustomDataset()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureBlobStorageLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new CustomDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TypeProperties = BinaryData.FromObjectAsJson(new
                {
                    PropertyBagPropertyName1 = "PropertyBagPropertyValue1",
                    propertyBagPropertyName2 = "PropertyBagPropertyValue2"
                })
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateOracleLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new OracleLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_OracleTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateOracleLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new OracleTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Description = "Example of Oracle with parameter, description, and expression",
                Parameters = { { "StartTime", new EntityParameterSpecification(EntityParameterType.String) { DefaultValue = BinaryData.FromString("\"2017-01-31T00:00:00Z\"") } } },
                TableName = DataFactoryElement<string>.FromExpression("\"@parameters('StartTime')\"")
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAmazonRdsForOracleLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AmazonRdsForOracleLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AmazonRdsForOracleTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAmazonRdsForOracleLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AmazonRdsForOracleTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Schema = new List<DatasetSchemaDataElement>()
                {
                    new DatasetSchemaDataElement(){ SchemaColumnName = "dbo",SchemaColumnType="string"}
                },
                Parameters = { { "StartTime", new EntityParameterSpecification(EntityParameterType.String) { DefaultValue = BinaryData.FromString("\"2017-01-31T00:00:00Z\"") } } },
                Table = DataFactoryElement<string>.FromExpression(@"@parameters('StartTime')")
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateODataLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new ODataLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_ODataResource()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateODataLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ODataResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Path = "path"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateCassandraLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new CassandraLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_CassandraTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateCassandraLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new CassandraTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TableName = "table",
                Keyspace = "keyspace"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateCosmosDBLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new CosmosDBLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("AccountEndpoint=https://binlu-cosmos.documents.azure.com:443/;Database=test;")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_CosmosDbSqlApiCollection()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateCosmosDBLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new CosmosDBSqlApiCollectionDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fake collection") { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateFileServerLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new FileServerLinkedService("\\testmachine\\testfolder"));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_FileShare()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateFileServerLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new FileShareDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                FolderPath = "Root\\MyFolder",
                FileName = "testfilename",
                Format = new DatasetStorageFormat() { DatasetStorageFormatType = "Acroformat" }
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAmazonS3LinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AmazonS3LinkedService()
            {
                AccessKeyId = "fakeaccess",
                SecretAccessKey = new DataFactorySecretString("fakekey")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AmazonS3Object()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAmazonS3LinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AmazonS3Dataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "sample name")
            {
                Key = "sample key",
                Prefix = "prefix",
                Version = "1.0.0",
                Format = new DatasetStorageFormat() { DatasetStorageFormatType = "ParquetFormat" },
                Compression = new DatasetCompression("Deflate") { Level = "Fastest" }
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateMongoDBLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new MongoDBLinkedService("server", "db") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_MongoDbCollection()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateMongoDBLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MongoDBCollectionDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "faketable") { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_RelationalTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureSqlDatabaseLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new RelationalTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { TableName = "$EncryptedString$MyEncryptedTableName" });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateWebLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            WebLinkedServiceTypeProperties webLinkedServiceTypeProperties = new UnknownWebLinkedServiceTypeProperties("http://localhost", WebAuthenticationType.ClientCertificate);

            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new WebLinkedService(webLinkedServiceTypeProperties) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_WebTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateWebLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new WebTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), 1)
            {
                Path = "\"MyContainer\\\\MySubFolder\\\\$Date\\\\$Time\\\\FileName$Date$Time\\\\{PartitionKey}\""
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureDataLakeStoreLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureDataLakeStoreLinkedService("datastoreuri") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureDataLakeStoreFile()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureDataLakeStoreLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureDataLakeStoreDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                FolderPath = "fakepath",
                FileName = "fakename",
                Format = new DatasetStorageFormat() { DatasetStorageFormatType = "TextFormat" }
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureSearchLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureSearchLinkedService("uri") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureSearchIndex()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureSearchLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureSearchIndexDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fakedIndexName") { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateHttpLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new HttpLinkedService("uri") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_HttpFile()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateHttpLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DataFactoryHttpDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                RelativeUri = "fakeuri",
                RequestMethod = "get",
                Format = new DatasetStorageFormat() { DatasetStorageFormatType = "Textformat" }
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureMySqlLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureMySqlLinkedService(DataFactoryElement<string>.FromSecretString("server=binlhf-testdriver.mysql.database.azure.com;port=3306;database=tests;uid=admin;sslmode=1;usesystemtruststore=0")) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureMySqlTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureMySqlLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureMySqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TableName = "$EncryptedString$MyEncryptedTableName"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSalesforceLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SalesforceLinkedService()
            {
                EnvironmentUri = "Uri",
                Username = "admin",
                Password = new DataFactorySecretString("fakepassword"),
                SecurityToken = new DataFactorySecretString("fakeToken"),
                ApiVersion = "27.0"
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SalesforceObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSalesforceLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SalesforceObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                ObjectApiName = "fakeObjectApiName"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSalesforceServiceCloudLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SalesforceServiceCloudLinkedService()
            {
                EnvironmentUri = "Uri",
                Username = "admin",
                Password = new DataFactorySecretString("fakepassword"),
                SecurityToken = new DataFactorySecretString("faketoken"),
                ApiVersion = "27.0"
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SalesforceServiceCloudObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSalesforceServiceCloudLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SalesforceServiceCloudObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                ObjectApiName = "fakeObjectApiName"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureBlobDataset()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureBlobStorageLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureBlobDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                FolderPath = "MyContainer\\MySubFolder\\$Date\\$Time\\FileName$Date$Time\\{PartitionKey}",
                FileName = "TestBlobName",
                Format = new DatasetJsonFormat()
                {
                    DatasetStorageFormatType = "JsonFormat",
                    NestingSeparator = ",",
                    FilePattern = BinaryData.FromString("\"setOfObjects\""),
                    EncodingName = "utf-8",
                    JsonNodeReference = "$.root",
                    JsonPathDefinition = BinaryData.FromObjectAsJson(@"{
                        ""PartitionKey"": ""$.PartitionKey"",
                        ""RowKey"": ""$.RowKey"",
                        ""p1"": ""p1"",
                        ""p2"": ""p2""
                    }")
                }
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSapCloudForCustomerLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData lkSapCloudForCustomer = new DataFactoryLinkedServiceData(new SapCloudForCustomerLinkedService("www.fakeuri.com")
            {
                Username = "fakeUsername",
                Password = new DataFactorySecretString("fakePassword")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSapCloudForCustomer);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SapCloudForCustomerResource()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSapCloudForCustomerLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SapCloudForCustomerResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "LeadCollection"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAmazonMwsLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AmazonMwsLinkedService("mws,amazonservices.com", "A2EUQ1WTGCTBG2", "ACGMZIK6QTD9T", "128393242334")
            {
                MwsAuthToken = new DataFactorySecretString("fakeMwsAuthToken"),
                SecretKey = new DataFactorySecretString("fakeSecretKey"),
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true,
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AmazonMWSObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAmazonMwsLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AmazonMwsObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzurePostgreSqlLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzurePostgreSqlLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("host=test123.postgres.database.azure.com;port=5432;database=testdb;uid=fakeuid;encryptionmethod=0")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzurePostgreSqlTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzurePostgreSqlLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzurePostgreSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateConcurLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new ConcurLinkedService("clientid", "username") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_ConcurObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateConcurLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ConcurObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateCouchbaseLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new CouchbaseLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_CouchbaseTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateCouchbaseLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new CouchbaseTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateDrillLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new DrillLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DrillTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateDrillLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DrillTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateEloquaLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new EloquaLinkedService("endpoint", "username") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_EloquaObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateEloquaLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new EloquaObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateGoogleBigQueryLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new GoogleBigQueryLinkedService("project", GoogleBigQueryAuthenticationType.ServiceAuthentication) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_GoogleBigQueryObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateGoogleBigQueryLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new GoogleBigQueryObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateGreenplumLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new GreenplumLinkedService()
            {
                ConnectionString = "SecureString"
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_GreenplumTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateGreenplumLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new GreenplumTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateHBaseLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new HBaseLinkedService("host", HBaseAuthenticationType.Anonymous)
            {
                HttpPath = "/gateway/sandbox/hbase/version",
                EnableSsl = true,
                AllowHostNameCNMismatch = true,
                AllowSelfSignedServerCert = true,
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_HBaseObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateGreenplumLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new HBaseObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateHiveLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new HiveLinkedService("host", HiveAuthenticationType.Anonymous) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_HiveObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateHiveLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new HiveObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateHubspotLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new HubspotLinkedService("clientid") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_HubspotObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateHubspotLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new HubspotObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateImpalaLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new ImpalaLinkedService("host", ImpalaAuthenticationType.Anonymous) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_ImpalaObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateImpalaLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ImpalaObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateJiraLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new JiraLinkedService("host", "username") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_JiraObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateJiraLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new JiraObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }
        private async Task<DataFactoryLinkedServiceResource> CreateMagentoLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new MagentoLinkedService("host") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_MagentoObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateMagentoLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MagentoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateMariaDBLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new MariaDBLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("server=10.0.23.113;port=21;database=database;uid=scaleouttest")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_MariaDBTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateMariaDBLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MariaDBTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureMariaDBLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureMariaDBLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("server=10.0.23.113;port=21;database=database;uid=scaleouttest")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureMariaDBTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureMariaDBLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureMariaDBTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateMarketoLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new MarketoLinkedService("endpoint", "clientid") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_MarketoObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateMarketoLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MarketoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> PaypalLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new PaypalLinkedService("host", "client") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_PaypalObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await PaypalLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new PaypalObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreatePhoenixLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new PhoenixLinkedService("host", PhoenixAuthenticationType.Anonymous) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_PhoenixObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreatePhoenixLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new PhoenixObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreatePrestoLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new PrestoLinkedService("host", "serverVersion", "catalog", PrestoAuthenticationType.Anonymous) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_PrestoObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreatePrestoLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new PrestoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateQuickBooksLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new QuickBooksLinkedService()
            {
                Endpoint = "quickbooks.api.intuit.com",
                CompanyId = "fakeCompanyId",
                ConsumerKey = "fakeConsumerKey",
                ConsumerSecret = new DataFactorySecretString("some secret"),
                AccessToken = new DataFactorySecretString("some secret"),
                AccessTokenSecret = new DataFactorySecretString("some secret"),
                UseEncryptedEndpoints = true,
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_QuickBooksObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateQuickBooksLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new QuickBooksObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateServiceNowLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new ServiceNowLinkedService("http://instance.service-now.com", ServiceNowAuthenticationType.Basic)
            {
                Username = "admin",
                Password = new DataFactorySecretString("some secret")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_ServiceNowObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateServiceNowLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ServiceNowObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateShopifyLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new ShopifyLinkedService("host") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_ShopifyObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateShopifyLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ShopifyObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSparkLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SparkLinkedService("host", 21, SparkAuthenticationType.Anonymous) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SparkObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSparkLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SparkObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSquareLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SquareLinkedService()
            {
                Host = "mystore.mysquare.com",
                ClientId = "clientIdFake",
                ClientSecret = new DataFactorySecretString("some secret"),
                RedirectUri = "http://localhost:2500",
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SquareObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSquareLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SquareObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateXeroLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new XeroLinkedService()
            {
                Host = "api.xero.com",
                ConsumerKey = new DataFactorySecretString("some secret"),
                PrivateKey = new DataFactorySecretString("some secret"),
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_XeroObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateXeroLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new XeroObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateZohoLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new ZohoLinkedService()
            {
                Endpoint = "crm.zoho.com/crm/private",
                AccessToken = new DataFactorySecretString("some secret"),
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_ZohoObject()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateZohoLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ZohoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSapEccLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SapEccLinkedService("Uri") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SapEccResource()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSapEccLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SapEccResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "dd04tentitySet") { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateNetezzaLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new NetezzaLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("server=testserver;port=1234;database=TestDB;uid=admin;securitylevel=preferredUnSecured")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_NetezzaTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateNetezzaLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new NetezzaTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }
        private async Task<DataFactoryLinkedServiceResource> CreateVerticaLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new VerticaLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_VerticaTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateVerticaLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new VerticaTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSapOpenHubLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SapOpenHubLinkedService()
            {
                MessageServer = "fakeserver",
                MessageServerService = "00",
                SystemId = "ecc",
                LogonGroup = "fakegroup",
                ClientId = "800",
                UserName = "user",
                Password = new DataFactorySecretString("fakepwd"),
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SapOpenHubTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSapOpenHubLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SapOpenHubTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fakeohdname")
            {
                ExcludeLastRequest = true,
                BaseRequestId = 231
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateRestServiceLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new RestServiceLinkedService("https://fakeurl/", RestServiceAuthenticationType.Basic)
            {
                UserName = "user",
                Password = new DataFactorySecretString("fakepwd"),
                AzureCloudType = "azurepublic"
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_RestResource()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateRestServiceLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new RestResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                RelativeUri = "\"https://fakeurl/\"",
                AdditionalHeaders = { { "x-user-defined", BinaryData.FromString("\"helloworld\"") } },
                PaginationRules = { { "AbsoluteUrl", BinaryData.FromString("\"$.paging.next\"") } }
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateOffice365LinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new Office365LinkedService("office365tenantid", "servicePrincipalTenantID", "servicePrincipalId", new DataFactorySecretString("servicePrincipalKey"))
            {
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Excel()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateOffice365LinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ExcelDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new AzureBlobStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FileName = "releases-1.xlsx", Container = "exceltest" },
                Compression = new DatasetCompression("Gzip") { Level = "Fasttest" },
                SheetName = "test01",
                Range = "A4:H9",
                NullValue = "N/A",
                FirstRowAsHeader = true
            })
            {
                Properties = {
                    Schema = new List<DatasetSchemaDataElement> {
                        new DatasetSchemaDataElement() { SchemaColumnName = "title", SchemaColumnType = "string" },
                        new DatasetSchemaDataElement() { SchemaColumnName = "movieID", SchemaColumnType = "string" }
                    }
                }
            };
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Excel_SheetIndex()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateOffice365LinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ExcelDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new AzureBlobStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FileName = "releases-1.xlsx", Container = "exceltest" },
                Compression = new DatasetCompression("Gzip") { Level = "Fasttest" },
                SheetName = "test01",
                Range = "A4:H9",
                NullValue = "N/A",
                FirstRowAsHeader = true,
                SheetIndex = 1
            })
            {
                Properties = {
                    Schema = new List<DatasetSchemaDataElement> {
                        new DatasetSchemaDataElement() { SchemaColumnName = "title", SchemaColumnType = "string" },
                        new DatasetSchemaDataElement() { SchemaColumnName = "movieID", SchemaColumnType = "string" }
                    }
                }
            };
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Parquet()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureBlobStorageLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ParquetDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new AzureBlobStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FileName = "data.parquet", Container = "ContainerName", FolderPath = "dataflow/test/input" },
                CompressionCodec = "gzip"
            })
            {
                Properties = {
                    Schema = new List<DatasetSchemaDataElement> {
                        new DatasetSchemaDataElement() {
                            SchemaColumnName = "col1",
                            SchemaColumnType = "INT_32"
                        },
                        new DatasetSchemaDataElement() {
                            SchemaColumnName = "col2",
                            SchemaColumnType = "Decimal",
                            AdditionalProperties = { { "scale",BinaryData.FromString("2")},{"precision",BinaryData.FromString("38") } }
                        }
                    }
                }
            };
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSapTableLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SapTableLinkedService()
            {
                Server = "fakeserver",
                SystemNumber = "00",
                ClientId = "000",
                UserName = "user",
                Password = new DataFactorySecretString("fakepwd"),
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SapTableResource()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSapTableLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SapTableResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "tablename") { });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DelimitedText_Schema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateFileServerLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new AzureBlobStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FileName = "test01", Container = "ContainerName", FolderPath = "xxxxx" },
                ColumnDelimiter = "\\n",
                RowDelimiter = "\\t",
                EncodingName = "UTF-8",
                CompressionCodec = "bzip2",
                CompressionLevel = "farest",
                QuoteChar = "",
                EscapeChar = "",
                FirstRowAsHeader = false,
                NullValue = "",
                Schema = new List<DatasetSchemaDataElement> {
                    new DatasetSchemaDataElement() {
                        SchemaColumnName = "col1",
                        SchemaColumnType = "INT_32"
                    },
                    new DatasetSchemaDataElement() {
                        SchemaColumnName = "col2",
                        SchemaColumnType = "Decimal",
                        AdditionalProperties = { { "scale",BinaryData.FromString("2")},{"precision",BinaryData.FromString("38") } }
                    }
                }
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Xml()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateFileServerLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new XmlDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new AzureBlobStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FileName = "test.json", Container = "ContainerName", FolderPath = "testfolder" },
                EncodingName = "UTF-8",
                NullValue = null,
                Compression = new DatasetCompression("Gzip") { Level = "optional" }
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Binary()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureBlobStorageLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new BinaryDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new AzureBlobStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FileName = "data.parquet", Container = "ContainerName", FolderPath = "testfolder" },
                Compression = new DatasetCompression("Deflate") { Level = "fartest" }
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Binary_Compression()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureBlobStorageLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new BinaryDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new AzureBlobStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FileName = "testTgz01", Container = "ContainerName", FolderPath = "testfolder" },
                Compression = new DatasetCompression("TarGzip") { Level = "optional" }
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Orc()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateOracleLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new OrcDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new AzureBlobStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FileName = "data.orc", Container = "ContainerName", FolderPath = "testfolder" },
                OrcCompressionCodec = "snappy",
            })
            {
                Properties = {
                    Schema = new List<DatasetSchemaDataElement> {
                        new DatasetSchemaDataElement() {
                            SchemaColumnName = "col1",
                            SchemaColumnType = "INT_32"
                        },
                        new DatasetSchemaDataElement() {
                            SchemaColumnName = "col2",
                            SchemaColumnType = "Decimal",
                            AdditionalProperties = { { "scale",BinaryData.FromString("2")},{"precision",BinaryData.FromString("38") } }
                        }
                    }
                }
            };
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Orc_OrcCompressionCodec()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateOracleLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new OrcDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new AzureBlobStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FileName = "data.orc", Container = "ContainerName", FolderPath = "testfolder" },
                OrcCompressionCodec = "lzo",
            })
            {
                Properties = {
                    Schema = new List<DatasetSchemaDataElement> {
                        new DatasetSchemaDataElement() {
                            SchemaColumnName = "col1",
                            SchemaColumnType = "INT_32"
                        },
                        new DatasetSchemaDataElement() {
                            SchemaColumnName = "col2",
                            SchemaColumnType = "Decimal",
                            AdditionalProperties = { { "scale",BinaryData.FromString("2")},{"precision",BinaryData.FromString("38") } }
                        }
                    }
                }
            };
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateTeradataLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new TeradataLinkedService()
            {
                Server = "fakeServerName",
                Username = "fakeUsername",
                AuthenticationType = TeradataAuthenticationType.Basic,
                Password = new DataFactorySecretString("fakePassword")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_TeradataTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateTeradataLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new TeradataTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Database = "AdventureWorksDW2012",
                Table = "DimAccount"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateDynamicsCrmLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new DynamicsCrmLinkedService("Online", "Office365")
            {
                HostName = "hostname.com",
                Port = 1234,
                OrganizationName = "contoso",
                Username = "fakeuser@contoso.com",
                Password = new DataFactorySecretString("fakepassword"),
                EncryptedCredential = "fake credential"
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DynamicsCrmEntity()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateDynamicsCrmLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DynamicsCrmEntityDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                EntityName = "test"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateCommonDataServiceForAppsLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new CommonDataServiceForAppsLinkedService("Online", "AadServicePrincipal")
            {
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                ServicePrincipalCredential = new DataFactorySecretString("fakepassword")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_CommonDataServiceForAppsEntity()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateCommonDataServiceForAppsLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new CommonDataServiceForAppsEntityDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                EntityName = "test"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateInformixLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new InformixLinkedService("Database=TestDB;Host=192.168.10.10;Server=db_engine_tcp;Service=1492;Protocol=onsoctcp;UID=fakeUsername;Password=fakePassword;"));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_InformixTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateInformixLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new InformixTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TableName = "test"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateMicrosoftAccessLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData lkMicrosoftAccess = new DataFactoryLinkedServiceData(new MicrosoftAccessLinkedService("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\myFolder\\myAccessFile.accdb;Persist Security Info=False;"));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkMicrosoftAccess);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_MicrosoftAccessTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateMicrosoftAccessLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MicrosoftAccessTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TableName = "test"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzurePostgreSqlTable_TableName()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzurePostgreSqlLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzurePostgreSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TableName = "$EncryptedString$MyEncryptedTableName"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateMySqlLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new MySqlLinkedService(DataFactoryElement<string>.FromSecretString("server=10.0.0.122;port=3306;database=db;user=https:\\\\test.com;sslmode=1;usesystemtruststore=0")) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_MySqlTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateMySqlLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MySqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TableName = "$EncryptedString$MyEncryptedTableName"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzurePostgreSqlTable_TableNameSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzurePostgreSqlLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzurePostgreSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TableName = "$EncryptedString$MyEncryptedTableName",
                SchemaTypePropertiesSchema = "$EncryptedString$MyEncryptedTableName"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }
        private async Task<DataFactoryLinkedServiceResource> CreateOdbcLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new OdbcLinkedService(DataFactoryElement<string>.FromSecretString("Driver={ODBC Driver 17 for SQL Server};Server=myServerAddress;Database=myDataBase;Uid=fakeUsername;Pwd=fakePassword;")));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_OdbcTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateOdbcLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new OdbcTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TableName = "$EncryptedString$MyEncryptedTableName"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureDataExplorerLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureDataExplorerLinkedService("https://fakecluster.eastus2.kusto.windows.net", "MyDatabase")
            {
                ServicePrincipalId = "fakeSPID",
                ServicePrincipalKey = new DataFactorySecretString("fakepwd"),
                Tenant = "faketenant"
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureDataExplorerTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureDataExplorerLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureDataExplorerTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "mytable"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSapBWLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SapBWLinkedService("fakeServer", "fakeNumber", "fakeId")
            {
                UserName = "fakeName",
                Password = new DataFactorySecretString("fakePassword"),
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SapBwCube()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSapBWLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SapBWCubeDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSybaseLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SybaseLinkedService("fakeServer", "fakeDB")
            {
                Username = "name",
                Password = new DataFactorySecretString("fakePassword"),
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SybaseTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSybaseLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SybaseTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                TableName = "$EncryptedString$MyEncryptedTableName"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_OracleTable_Description()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateOracleLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new OracleTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            })
            {
                Properties ={
                    Description ="Example of Oracle with parameter, description, and expression"
                }
            };
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureSqlTable_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureSqlDatabaseLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }
        private async Task<DataFactoryLinkedServiceResource> CreateAmazonRdsForSqlServerLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AmazonRdsForSqlServerLinkedService(DataFactoryElement<string>.FromSecretString("integrated security=False;data source=TestServer;initial catalog=TestDB;"))
            {
                UserName = "WindowsAuthUserName",
                Password = new DataFactorySecretString("fakepassword")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }
        [Test]
        [RecordedTest]
        public async Task Dataset_AmazonRdsForSqlServerTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAmazonRdsForSqlServerLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AmazonRdsForSqlServerTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            }
            );
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureSqlDWTable_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureSqlDWLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureSqlDWTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SqlServerTable_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSqlServerLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SqlServerTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DrillTable_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateDrillLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DrillTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_GoogleBigQueryObject_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateGoogleBigQueryLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new GoogleBigQueryObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                DatasetType = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_GreenplumTable_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateGreenplumLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new GreenplumTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_HiveObject_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateHiveLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new HiveObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_ImpalaObject_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateImpalaLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ImpalaObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_PhoenixObject_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreatePhoenixLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new PhoenixObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_PrestoObject_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreatePrestoLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new PrestoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SparkObject_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSparkLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SparkObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_VerticaTable_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateVerticaLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new VerticaTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_NetezzaTable_TableSchema()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateNetezzaLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new NetezzaTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreatePostgreSqlLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzurePostgreSqlLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("host=fakeServer.postgres.database.azure.com;port=5432;database=TestDB;uid=tests;encryptionmethod=0")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_PostgreSqlTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreatePostgreSqlLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new PostgreSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }
        private async Task<DataFactoryLinkedServiceResource> CreateAmazonRedshiftLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AmazonRedshiftLinkedService("fakeserver.com", "fakedb")
            {
                Port = 1234,
                Username = "fakeuser@contoso.com",
                Password = new DataFactorySecretString("fakepassword"),
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }
        [Test]
        [RecordedTest]
        public async Task Dataset_AmazonRedshiftTable()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAmazonRedshiftLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AmazonRedshiftTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateDb2LinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new Db2LinkedService()
            {
                ConnectionString = "Server=fakeServer;Database=fakeTestDb;AuthenticationType=Basic;UserName=fakeUsername;PackageCollection=fakePackageCollection;CertificateCommonName=fakeCertificateCommonName",
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }
        [Test]
        [RecordedTest]
        public async Task Dataset_Db2Table()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateDb2LinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new Db2TableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "testtable",
                SchemaTypePropertiesSchema = "dbo"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureMySqlTable_Table()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateAzureMySqlLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureMySqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                Table = "$EncryptedString$MyEncryptedTable",
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DelimitedText()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateFileServerLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new AzureFileStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FolderPath = "folder/subfolder", AdditionalProperties = { { "bucketname", BinaryData.FromString("\"bucketname\"") } } },
                ColumnDelimiter = ",",
                CompressionCodec = "Gzip",
                QuoteChar = "\\",
                FirstRowAsHeader = true,
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DelimitedText_GoogleCloudStorageLocation()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateFileServerLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new GoogleCloudStorageLocation() { DatasetLocationType = "GoogleCloudStorageLocation", FolderPath = "folder/subfolder", BucketName = "buckname" },
                ColumnDelimiter = ",",
                CompressionCodec = "Gzip",
                QuoteChar = "\\",
                FirstRowAsHeader = true,
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DelimitedText_AmazonS3CompatibleLocation()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateFileServerLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new AmazonS3CompatibleLocation() { DatasetLocationType = "AmazonS3CompatibleLocation", Version = "version", BucketName = "buckname" },
                ColumnDelimiter = ",",
                CompressionCodec = "Gzip",
                QuoteChar = "\\",
                FirstRowAsHeader = true,
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DelimitedText_OracleCloudStorageLocation()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateFileServerLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                DataLocation = new OracleCloudStorageLocation() { DatasetLocationType = "OracleCloudStorageLocation", Version = "version", BucketName = "buckname" },
                ColumnDelimiter = ",",
                CompressionCodec = "Gzip",
                QuoteChar = "\\",
                FirstRowAsHeader = true,
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSharePointOnlineListLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SharePointOnlineListLinkedService("http://localhost/webhdfs/v1/", "tenantId", "servicePrincipalId", new DataFactorySecretString("ServicePrincipalKey")) { }) { Properties = { Description = "test description" } };

            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SharePointOnlineListResource()
        {
            // Get the resource group
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"DataFactory-{MethodBase.GetCurrentMethod().DeclaringType.GUID}-");
            DataFactoryResource dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
            // Create a LinkedService
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            await CreateLinkedService(dataFactory, _linkedServiceName, _accessKey);
            string datasetName = Recording.GenerateAssetName("dataset");
            string linkedServiceName = Recording.GenerateAssetName("linkedSerivce-");
            await CreateSharePointOnlineListLinkedService(dataFactory, linkedServiceName);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SharePointOnlineListResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
            {
                ListName = "listname"
            });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            Assert.NotNull(result.Value.Id);
            await GlobalTearDown();
        }
    }
}
