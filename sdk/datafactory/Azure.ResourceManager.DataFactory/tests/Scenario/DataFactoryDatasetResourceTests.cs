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

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryDatasetResourceTests : DataFactoryManagementTestBase
    {
        public DataFactoryDatasetResourceTests(bool isAsync) : base(isAsync)
        {
        }

        private string GetStorageAccountAccessKey(ResourceGroupResource resourceGroup)
        {
            var storageAccountName = Recording.GenerateAssetName("adfstorage");
            return GetStorageAccountAccessKey(resourceGroup, storageAccountName).Result;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDataset(DataFactoryResource dataFactory, string datasetName, string linkedServiceName)
        {
            DataFactoryLinkedServiceReference linkedServiceReference = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName);
            DataFactoryDatasetProperties properties = new AzureSqlTableDataset(linkedServiceReference);
            DataFactoryDatasetData data = new DataFactoryDatasetData(properties);
            var dataset = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return dataset.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Create_Exists_Get_List_Delete()
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName("adf-rg-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName("adf-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);
            // Create a LinkedService
            string accessKey = GetStorageAccountAccessKey(resourceGroup);
            string linkedServiceName = Recording.GenerateAssetName("adf-linkedservice-");
            await CreateLinkedService(dataFactory, linkedServiceName, accessKey);
            // Create Dataset
            string datasetName = Recording.GenerateAssetName("adf-dataset-");
            var dataset = await CreateDefaultDataset(dataFactory, datasetName, linkedServiceName);
            Assert.IsNotNull(dataset);
            Assert.AreEqual(datasetName, dataset.Data.Name);
            // Exists
            bool flag = await dataFactory.GetDataFactoryDatasets().ExistsAsync(datasetName);
            Assert.IsTrue(flag);
            // Get
            var datasetGet = await dataFactory.GetDataFactoryDatasets().GetAsync(datasetName);
            Assert.IsNotNull(dataset);
            Assert.AreEqual(datasetName, datasetGet.Value.Data.Name);
            // GetAll
            var list = await dataFactory.GetDataFactoryDatasets().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
            // Delete
            await dataset.DeleteAsync(WaitUntil.Completed);
            flag = await dataFactory.GetDataFactoryDatasets().ExistsAsync(datasetName);
            Assert.IsFalse(flag);
        }

        public async Task DatasetCreate(string name, Func<DataFactoryResource, string, Task<DataFactoryLinkedServiceResource>> linkedServiceFunc, Func<string, DataFactoryDatasetData> dataFunc)
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName($"adf-rg-{name}-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"adf-{name}-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);
            // Create a LinkedService
            string accessKey = GetStorageAccountAccessKey(resourceGroup);
            string linkedServiceName = Recording.GenerateAssetName($"adf-linkedservice-{name}-");
            await CreateLinkedService(dataFactory, linkedServiceName, accessKey);
            await linkedServiceFunc(dataFactory, linkedServiceName);
            // Create Dataset
            string datasetName = Recording.GenerateAssetName($"adf-dataset-{name}-");
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, dataFunc(linkedServiceName));
            Assert.NotNull(result.Value.Id);
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
        public async Task Dataset_AzureBlob_Create()
        {
            await DatasetCreate("blob", CreateAzureBlobStorageLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureBlobDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
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
            });
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
        public async Task Dataset_AzureDatabricksDeltaLake_Create()
        {
            await DatasetCreate("databricks", CreateAzureDatabricksDeltaLakeLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureDatabricksDeltaLakeDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "azuretable",
                    Database = "default"
                });
            });
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
        public async Task Dataset_AzureTable_Create()
        {
            await DatasetCreate("table", CreateAzureTableStorageLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "table$Date$Time") { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureSqlDatabaseLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureSqlDatabaseLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureSqlTable_Create()
        {
            await DatasetCreate("asql", CreateAzureSqlDatabaseLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TableName = "MyEncryptedTableName"
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureSqlMILinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureSqlMILinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureSqlMITable_Create()
        {
            await DatasetCreate("asqlmi", CreateAzureSqlMILinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Schema = new List<DatasetSchemaDataElement>()
                    {
                        new DatasetSchemaDataElement(){ SchemaColumnName = "dbo",SchemaColumnType="string"}
                    },
                    Table = "test",
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureSqlDWLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureSqlDWLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureSqlDWTable_Create()
        {
            await DatasetCreate("asqlmw", CreateAzureSqlDWLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureSqlDWTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TableName = "MyEncryptedTableName"
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSqlServerLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SqlServerLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SqlServerTable_Create()
        {
            await DatasetCreate("sql", CreateSqlServerLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SqlServerTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TableName = BinaryData.FromString("\"MyEncryptedTableName\"")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_CustomDataset_Create()
        {
            await DatasetCreate("custom", CreateAzureBlobStorageLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new CustomDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TypeProperties = BinaryData.FromObjectAsJson(new
                    {
                        PropertyBagPropertyName1 = "PropertyBagPropertyValue1",
                        propertyBagPropertyName2 = "PropertyBagPropertyValue2"
                    })
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateOracleLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new OracleLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_OracleTable_Create()
        {
            await DatasetCreate("oracle", CreateOracleLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new OracleTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Description = "Example of Oracle with parameter, description, and expression",
                    Parameters = { { "StartTime", new EntityParameterSpecification(EntityParameterType.String) { DefaultValue = BinaryData.FromString("\"2017-01-31T00:00:00Z\"") } } },
                    TableName = DataFactoryElement<string>.FromExpression("\"@parameters('StartTime')\"")
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAmazonRdsForOracleLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AmazonRdsForOracleLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AmazonRdsForOracleTable_Create()
        {
            await DatasetCreate("rds", CreateAmazonRdsForOracleLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AmazonRdsForOracleTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Schema = new List<DatasetSchemaDataElement>()
                    {
                        new DatasetSchemaDataElement(){ SchemaColumnName = "dbo",SchemaColumnType="string"}
                    },
                    Parameters = { { "StartTime", new EntityParameterSpecification(EntityParameterType.String) { DefaultValue = BinaryData.FromString("\"2017-01-31T00:00:00Z\"") } } },
                    Table = DataFactoryElement<string>.FromExpression(@"@parameters('StartTime')")
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateODataLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new ODataLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_OData_Create()
        {
            await DatasetCreate("odata", CreateODataLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new ODataResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Path = "path"
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateCassandraLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new CassandraLinkedService("DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_CassandraTable_Create()
        {
            await DatasetCreate("cassandra", CreateCassandraLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new CassandraTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TableName = "table",
                    Keyspace = "keyspace"
                });
            });
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
        public async Task Dataset_CosmosDb_Create()
        {
            await DatasetCreate("cosmosdb", CreateCosmosDBLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new CosmosDBSqlApiCollectionDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fake collection") { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateFileServerLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new FileServerLinkedService("\\testmachine\\testfolder"));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_FileShare_Create()
        {
            await DatasetCreate("file", CreateFileServerLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new FileShareDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    FolderPath = "Root\\MyFolder",
                    FileName = "testfilename",
                    Format = new DatasetAvroFormat()
                });
            });
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
        public async Task Dataset_AmazonS3Object_Create()
        {
            await DatasetCreate("s3", CreateAmazonS3LinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AmazonS3Dataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "sample name")
                {
                    Key = "sample key",
                    Prefix = "prefix",
                    Version = "1.0.0",
                    Format = new DatasetParquetFormat(),
                    Compression = new DatasetCompression("Deflate") { Level = "Fastest" }
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateMongoDBLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new MongoDBLinkedService("server", "db") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_MongoDb_Create()
        {
            await DatasetCreate("mongodb", CreateMongoDBLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new MongoDBCollectionDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "faketable") { });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_RelationalTable_Create()
        {
            await DatasetCreate("rt", CreateAzureSqlDatabaseLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new RelationalTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { TableName = "$EncryptedString$MyEncryptedTableName" });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateWebLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            WebLinkedServiceTypeProperties webLinkedServiceTypeProperties = new UnknownWebLinkedServiceTypeProperties("http://localhost", WebAuthenticationType.ClientCertificate, null);

            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new WebLinkedService(webLinkedServiceTypeProperties) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_WebTable_Create()
        {
            await DatasetCreate("web", CreateWebLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new WebTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), 1)
                {
                    Path = "\"MyContainer\\\\MySubFolder\\\\$Date\\\\$Time\\\\FileName$Date$Time\\\\{PartitionKey}\""
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureDataLakeStoreLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureDataLakeStoreLinkedService("datastoreuri") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureDataLakeStoreFile_Create()
        {
            await DatasetCreate("dlake", CreateAzureDataLakeStoreLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureDataLakeStoreDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    FolderPath = "fakepath",
                    FileName = "fakename",
                    Format = new DatasetTextFormat()
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureSearchLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureSearchLinkedService("uri") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureSearchIndex_Create()
        {
            await DatasetCreate("search", CreateAzureSearchLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureSearchIndexDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fakedIndexName") { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateHttpLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new HttpLinkedService("uri") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_HttpFile_Create()
        {
            await DatasetCreate("http", CreateHttpLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new DataFactoryHttpDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    RelativeUri = "fakeuri",
                    RequestMethod = "get",
                    Format = new DatasetTextFormat()
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateAzureMySqlLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new AzureMySqlLinkedService(DataFactoryElement<string>.FromSecretString("server=binlhf-testdriver.mysql.database.azure.com;port=3306;database=tests;uid=admin;sslmode=1;usesystemtruststore=0")) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureMySqlTable_Create()
        {
            await DatasetCreate("amysql", CreateAzureMySqlLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureMySqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TableName = "$EncryptedString$MyEncryptedTableName"
                });
            });
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
        public async Task Dataset_SalesforceObject_Create()
        {
            await DatasetCreate("salesforce", CreateSalesforceLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SalesforceObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    ObjectApiName = "fakeObjectApiName"
                });
            });
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
        public async Task Dataset_SalesforceServiceCloudObject_Create()
        {
            await DatasetCreate("salesforcec", CreateSalesforceServiceCloudLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SalesforceServiceCloudObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    ObjectApiName = "fakeObjectApiName"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureBlobDataset_Create()
        {
            await DatasetCreate("blob", CreateAzureBlobStorageLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureBlobDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
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
                        JsonPathDefinition = BinaryData.FromObjectAsJson(new
                        {
                            PartitionKey = "$.PartitionKey",
                            RowKey = "$.RowKey",
                            p1 = "p1",
                            p2 = "p2"
                        })
                    }
                });
            });
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
        public async Task Dataset_SapCloudForCustomerResource_Create()
        {
            await DatasetCreate("sapc", CreateSapCloudForCustomerLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SapCloudForCustomerResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "LeadCollection"));
            });
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
        public async Task Dataset_AmazonMwsObject_Create()
        {
            await DatasetCreate("mws", CreateAmazonMwsLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AmazonMwsObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_AzurePostgreSqlTable_Create()
        {
            await DatasetCreate("apsql", CreateAzurePostgreSqlLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzurePostgreSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateConcurLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new ConcurLinkedService("clientid", "username") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_ConcurObject_Create()
        {
            await DatasetCreate("concur", CreateConcurLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new ConcurObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_CouchbaseTable_Create()
        {
            await DatasetCreate("couchbase", CreateCouchbaseLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new CouchbaseTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_DrillTable_Create()
        {
            await DatasetCreate("drill", CreateDrillLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new DrillTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateEloquaLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new EloquaLinkedService("endpoint", "username") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_EloquaObject_Create()
        {
            await DatasetCreate("eloqua", CreateEloquaLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new EloquaObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateGoogleBigQueryLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new GoogleBigQueryLinkedService("project", GoogleBigQueryAuthenticationType.ServiceAuthentication) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_GoogleBigQueryObject_Create()
        {
            await DatasetCreate("gbigquery", CreateGoogleBigQueryLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new GoogleBigQueryObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_GreenplumTable_Create()
        {
            await DatasetCreate("greenp", CreateGreenplumLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new GreenplumTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_HBaseObject_Create()
        {
            await DatasetCreate("hbase", CreateHBaseLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new HBaseObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateHiveLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new HiveLinkedService("host", HiveAuthenticationType.Anonymous) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_HiveObject_Create()
        {
            await DatasetCreate("hive", CreateHiveLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new HiveObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateHubspotLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new HubspotLinkedService("clientid") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_HubspotObject_Create()
        {
            await DatasetCreate("hubspot", CreateHubspotLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new HubspotObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateImpalaLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new ImpalaLinkedService("host", ImpalaAuthenticationType.Anonymous) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_ImpalaObject_Create()
        {
            await DatasetCreate("impala", CreateImpalaLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new ImpalaObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateJiraLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new JiraLinkedService("host", "username") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_JiraObject_Create()
        {
            await DatasetCreate("jira", CreateJiraLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new JiraObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }
        private async Task<DataFactoryLinkedServiceResource> CreateMagentoLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new MagentoLinkedService("host") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_MagentoObject_Create()
        {
            await DatasetCreate("magento", CreateMagentoLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new MagentoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_MariaDBTable_Create()
        {
            await DatasetCreate("mariadb", CreateMariaDBLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new MariaDBTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_AzureMariaDBTable_Create()
        {
            await DatasetCreate("amariadb", CreateAzureMariaDBLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureMariaDBTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateMarketoLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new MarketoLinkedService("endpoint", "clientid") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_MarketoObject_Create()
        {
            await DatasetCreate("marketo", CreateMarketoLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new MarketoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreatePaypalLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new PaypalLinkedService("host", "client") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_PaypalObject_Create()
        {
            await DatasetCreate("paypal", CreatePaypalLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new PaypalObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreatePhoenixLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new PhoenixLinkedService("host", PhoenixAuthenticationType.Anonymous) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_PhoenixObject_Create()
        {
            await DatasetCreate("phoenix", CreatePhoenixLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new PhoenixObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreatePrestoLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new PrestoLinkedService("host", "serverVersion", "catalog", PrestoAuthenticationType.Anonymous) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_PrestoObject_Create()
        {
            await DatasetCreate("presto", CreatePrestoLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new PrestoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_QuickBooksObject_Create()
        {
            await DatasetCreate("quickbooks", CreateQuickBooksLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new QuickBooksObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_ServiceNowObject_Create()
        {
            await DatasetCreate("servicenow", CreateServiceNowLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new ServiceNowObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateShopifyLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new ShopifyLinkedService("host") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_ShopifyObject_Create()
        {
            await DatasetCreate("shopify", CreateShopifyLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new ShopifyObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSparkLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SparkLinkedService("host", 21, SparkAuthenticationType.Anonymous) { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SparkObject_Create()
        {
            await DatasetCreate("spark", CreateSparkLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SparkObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_SquareObject_Create()
        {
            await DatasetCreate("square", CreateSquareLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SquareObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_XeroObject_Create()
        {
            await DatasetCreate("xero", CreateXeroLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new XeroObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_ZohoObject_Create()
        {
            await DatasetCreate("zoho", CreateZohoLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new ZohoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSapEccLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SapEccLinkedService("Uri") { });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SapEccResource_Create()
        {
            await DatasetCreate("sapecc", CreateSapEccLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SapEccResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "dd04tentitySet") { });
            });
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
        public async Task Dataset_NetezzaTable_Create()
        {
            await DatasetCreate("netezza", CreateNetezzaLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new NetezzaTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_VerticaTable_Create()
        {
            await DatasetCreate("vertica", CreateVerticaLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new VerticaTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { });
            });
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
        public async Task Dataset_SapOpenHubTable_Create()
        {
            await DatasetCreate("sapopenhub", CreateSapOpenHubLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SapOpenHubTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fakeohdname")
                {
                    ExcludeLastRequest = true,
                    BaseRequestId = 231
                });
            });
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
        public async Task Dataset_RestResource_Create()
        {
            await DatasetCreate("rest", CreateRestServiceLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new RestResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    RelativeUri = "\"https://fakeurl/\"",
                    AdditionalHeaders = { { "x-user-defined", BinaryData.FromString("\"helloworld\"") } },
                    PaginationRules = { { "AbsoluteUrl", BinaryData.FromString("\"$.paging.next\"") } }
                });
            });
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
        public async Task Dataset_Excel_Create()
        {
            await DatasetCreate("excel", CreateOffice365LinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new ExcelDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
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
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Excel_SheetIndex_Create()
        {
            await DatasetCreate("excelsheet", CreateOffice365LinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new ExcelDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
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
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Parquet_Create()
        {
            await DatasetCreate("parquet", CreateAzureBlobStorageLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new ParquetDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
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
            });
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
        public async Task Dataset_SapTableResource_Create()
        {
            await DatasetCreate("saptable", CreateSapTableLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SapTableResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "tablename") { });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DelimitedText_Schema_Create()
        {
            await DatasetCreate("delimitedtext", CreateFileServerLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
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
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Xml_Create()
        {
            await DatasetCreate("xml", CreateFileServerLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new XmlDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    DataLocation = new AzureBlobStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FileName = "test.json", Container = "ContainerName", FolderPath = "testfolder" },
                    EncodingName = "UTF-8",
                    NullValue = null,
                    Compression = new DatasetCompression("Gzip") { Level = "optional" }
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Binary_Create()
        {
            await DatasetCreate("binary", CreateAzureBlobStorageLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new BinaryDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    DataLocation = new AzureBlobStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FileName = "data.parquet", Container = "ContainerName", FolderPath = "testfolder" },
                    Compression = new DatasetCompression("Deflate") { Level = "fartest" }
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Binary_Compression_Create()
        {
            await DatasetCreate("binaryzip", CreateAzureBlobStorageLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new BinaryDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    DataLocation = new AzureBlobStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FileName = "testTgz01", Container = "ContainerName", FolderPath = "testfolder" },
                    Compression = new DatasetCompression("TarGzip") { Level = "optional" }
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Orc_Create()
        {
            await DatasetCreate("orc", CreateOracleLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new OrcDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
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
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Orc_OrcCompressionCodec_Create()
        {
            await DatasetCreate("orczip", CreateOracleLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new OrcDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
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
            });
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
        public async Task Dataset_TeradataTable_Create()
        {
            await DatasetCreate("teradata", CreateTeradataLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new TeradataTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Database = "AdventureWorksDW2012",
                    Table = "DimAccount"
                });
            });
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
        public async Task Dataset_DynamicsCrmEntity_Create()
        {
            await DatasetCreate("dynamicscrm", CreateDynamicsCrmLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new DynamicsCrmEntityDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    EntityName = "test"
                });
            });
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
        public async Task Dataset_CommonDataServiceForAppsEntity_Create()
        {
            await DatasetCreate("cds4apps", CreateCommonDataServiceForAppsLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new CommonDataServiceForAppsEntityDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    EntityName = "test"
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateInformixLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new InformixLinkedService("Database=TestDB;Host=192.168.10.10;Server=db_engine_tcp;Service=1492;Protocol=onsoctcp;UID=fakeUsername;Password=fakePassword;"));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_InformixTable_Create()
        {
            await DatasetCreate("informix", CreateInformixLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new InformixTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TableName = "test"
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateMicrosoftAccessLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData lkMicrosoftAccess = new DataFactoryLinkedServiceData(new MicrosoftAccessLinkedService("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\myFolder\\myAccessFile.accdb;Persist Security Info=False;"));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkMicrosoftAccess);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_MicrosoftAccessTable_Create()
        {
            await DatasetCreate("access", CreateMicrosoftAccessLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new MicrosoftAccessTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TableName = "test"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzurePostgreSqlTable_TableName_Create()
        {
            await DatasetCreate("apsqln", CreateAzurePostgreSqlLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzurePostgreSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TableName = "$EncryptedString$MyEncryptedTableName"
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateMySqlLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new MySqlLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("server=10.0.0.122;port=3306;database=db;user=https:\\\\test.com;sslmode=1;usesystemtruststore=0")
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_MySqlTable_Create()
        {
            await DatasetCreate("mysql", CreateMySqlLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new MySqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TableName = "$EncryptedString$MyEncryptedTableName"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzurePostgreSqlTable_TableNameSchema_Create()
        {
            await DatasetCreate("apsqls", CreateAzurePostgreSqlLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzurePostgreSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TableName = "$EncryptedString$MyEncryptedTableName",
                    SchemaTypePropertiesSchema = "$EncryptedString$MyEncryptedTableName"
                });
            });
        }
        private async Task<DataFactoryLinkedServiceResource> CreateOdbcLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new OdbcLinkedService(DataFactoryElement<string>.FromSecretString("Driver={ODBC Driver 17 for SQL Server};Server=myServerAddress;Database=myDataBase;Uid=fakeUsername;Pwd=fakePassword;")));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_OdbcTable_Create()
        {
            await DatasetCreate("odbc", CreateOdbcLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new OdbcTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TableName = "$EncryptedString$MyEncryptedTableName"
                });
            });
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
        public async Task Dataset_AzureDataExplorerTable_Create()
        {
            await DatasetCreate("ade", CreateAzureDataExplorerLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureDataExplorerTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "mytable"
                });
            });
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
        public async Task Dataset_SapBwCube_Create()
        {
            await DatasetCreate("sapbw", CreateSapBWLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SapBWCubeDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                });
            });
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
        public async Task Dataset_SybaseTable_Create()
        {
            await DatasetCreate("sybase", CreateSybaseLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SybaseTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    TableName = "$EncryptedString$MyEncryptedTableName"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_OracleTable_Description_Create()
        {
            await DatasetCreate("oracledes", CreateOracleLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new OracleTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                })
                {
                    Properties = {
                        Description ="Example of Oracle with parameter, description, and expression"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureSqlTable_TableSchema_Create()
        {
            await DatasetCreate("asqlt", CreateAzureSqlDatabaseLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
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
        public async Task Dataset_AmazonRdsForSqlServerTable_Create()
        {
            await DatasetCreate("rdssql", CreateAmazonRdsForSqlServerLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AmazonRdsForSqlServerTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureSqlDWTable_TableSchema_Create()
        {
            await DatasetCreate("asqldws", CreateAzureSqlDWLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureSqlDWTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SqlServerTable_TableSchema_Create()
        {
            await DatasetCreate("sqlt", CreateSqlServerLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SqlServerTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DrillTable_TableSchema_Create()
        {
            await DatasetCreate("drillt", CreateDrillLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new DrillTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_GoogleBigQueryObject_TableSchema_Create()
        {
            await DatasetCreate("bigqueryt", CreateGoogleBigQueryLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new GoogleBigQueryObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    DatasetType = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_GreenplumTable_TableSchema_Create()
        {
            await DatasetCreate("greenplumt", CreateGreenplumLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new GreenplumTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_HiveObject_TableSchema_Create()
        {
            await DatasetCreate("hivet", CreateHiveLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new HiveObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_ImpalaObject_TableSchema_Create()
        {
            await DatasetCreate("impalat", CreateImpalaLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new ImpalaObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_PhoenixObject_TableSchema_Create()
        {
            await DatasetCreate("phoenixt", CreatePhoenixLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new PhoenixObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_PrestoObject_TableSchema_Create()
        {
            await DatasetCreate("prestot", CreatePrestoLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new PrestoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SparkObject_TableSchema_Create()
        {
            await DatasetCreate("sparkt", CreateSparkLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SparkObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_VerticaTable_TableSchema_Create()
        {
            await DatasetCreate("verticalt", CreateVerticaLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new VerticaTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_NetezzaTable_TableSchema_Create()
        {
            await DatasetCreate("netezzat", CreateNetezzaLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new NetezzaTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
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
        public async Task Dataset_PostgreSqlTable_Create()
        {
            await DatasetCreate("psql", CreatePostgreSqlLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new PostgreSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
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
        public async Task Dataset_AmazonRedshiftTable_Create()
        {
            await DatasetCreate("redshift", CreateAmazonRedshiftLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AmazonRedshiftTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
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
        public async Task Dataset_Db2Table_Create()
        {
            await DatasetCreate("db2", CreateDb2LinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new Db2TableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "testtable",
                    SchemaTypePropertiesSchema = "dbo"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_AzureMySqlTable_Table_Create()
        {
            await DatasetCreate("amysqlt", CreateAzureMySqlLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AzureMySqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Table = "$EncryptedString$MyEncryptedTable",
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DelimitedText_Create()
        {
            await DatasetCreate("delimitedtexta", CreateFileServerLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    DataLocation = new AzureFileStorageLocation() { DatasetLocationType = "AzureBlobStorageLocation", FolderPath = "folder/subfolder", AdditionalProperties = { { "bucketname", BinaryData.FromString("\"bucketname\"") } } },
                    ColumnDelimiter = ",",
                    CompressionCodec = "Gzip",
                    QuoteChar = "\\",
                    FirstRowAsHeader = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DelimitedText_GoogleCloudStorageLocation_Create()
        {
            await DatasetCreate("delimitedtextg", CreateFileServerLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    DataLocation = new GoogleCloudStorageLocation() { DatasetLocationType = "GoogleCloudStorageLocation", FolderPath = "folder/subfolder", BucketName = "buckname" },
                    ColumnDelimiter = ",",
                    CompressionCodec = "Gzip",
                    QuoteChar = "\\",
                    FirstRowAsHeader = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DelimitedText_AmazonS3CompatibleLocation_Create()
        {
            await DatasetCreate("delimitedtexts", CreateFileServerLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    DataLocation = new AmazonS3CompatibleLocation() { DatasetLocationType = "AmazonS3CompatibleLocation", Version = "version", BucketName = "buckname" },
                    ColumnDelimiter = ",",
                    CompressionCodec = "Gzip",
                    QuoteChar = "\\",
                    FirstRowAsHeader = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_DelimitedText_OracleCloudStorageLocation_Create()
        {
            await DatasetCreate("delimitedtexto", CreateFileServerLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    DataLocation = new OracleCloudStorageLocation() { DatasetLocationType = "OracleCloudStorageLocation", Version = "version", BucketName = "buckname" },
                    ColumnDelimiter = ",",
                    CompressionCodec = "Gzip",
                    QuoteChar = "\\",
                    FirstRowAsHeader = true,
                });
            });
        }

        private async Task<DataFactoryLinkedServiceResource> CreateSharePointOnlineListLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData linkedService = new DataFactoryLinkedServiceData(new SharePointOnlineListLinkedService("http://localhost/webhdfs/v1/", "tenantId", "servicePrincipalId", new DataFactorySecretString("ServicePrincipalKey")) { }) { Properties = { Description = "test description" } };

            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedService);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_SharePointOnlineListResource_Create()
        {
            await DatasetCreate("sharepoint", CreateSharePointOnlineListLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new SharePointOnlineListResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    ListName = "listname"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Avro_Create()
        {
            await DatasetCreate("avro", CreateAzureBlobStorageLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new AvroDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Schema = DataFactoryElement<BinaryData>.FromLiteral(BinaryData.FromString("{\"type\": \"record\",\"name\": \"HybridDelivery.ClientLibraryJob\",\"fields\": [{\"name\": \"TIMESTAMP\",\"type\": [\"string\",\"null\"]}]}")),
                    DataLocation = new AzureBlobStorageLocation()
                    {
                        FileName = "TestQuerySchema.avro",
                        FolderPath = "querytest"
                    }
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Dataset_Json_Create()
        {
            await DatasetCreate("json", CreateAzureBlobStorageLinkedService, (string linkedServiceName) =>
            {
                return new DataFactoryDatasetData(new JsonDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
                {
                    Schema = DataFactoryElement<BinaryData>.FromLiteral(BinaryData.FromString("{\"type\": \"object\",\"properties\": {\"studentName\": {\"type\": \"string\"},\"age\": {\"type\": \"integer\"},\"gender\": {\"type\": \"string\"},\"studentID\": {\"type\": \"string\"},\"major\": {\"type\": \"string\"},\"grades\": {\"type\": \"object\",\"properties\": {\"math\": {\"type\": \"integer\"},\"english\": {\"type\": \"integer\"},\"programming\": {\"type\": \"integer\"}}},\"contact\": {\"type\":\"object\",\"properties\": {\"phone\": {\"type\": \"string\"},\"email\": {\"type\": \"string\"}}}}}")),
                    DataLocation = new AzureBlobStorageLocation()
                    {
                        FileName = "TestQuerySchema.json",
                        FolderPath = "querytest"
                    }
                });
            });
        }
    }
}
