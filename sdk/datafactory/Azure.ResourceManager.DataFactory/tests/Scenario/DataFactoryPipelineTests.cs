// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryPipelineTests : DataFactoryManagementTestBase
    {
        public DataFactoryPipelineTests(bool isAsync) : base(isAsync)
        {
        }

        public async Task<DataFactoryResource> TestSetup()
        {
            string rgName = Recording.GenerateAssetName("DataFactory-RG-");
            string dataFactoryName = Recording.GenerateAssetName("DataFactory-");
            var subscription = await Client.GetDefaultSubscriptionAsync();
            var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            return await CreateDataFactory((Client.GetResourceGroupResource(rgLro.Value.Data.Id)), dataFactoryName);
        }

        private async Task<DataFactoryPipelineResource> CreateDefaultEmptyPipeLine(DataFactoryResource dataFactory, string pipelineName)
        {
            DataFactoryPipelineData data = new DataFactoryPipelineData() { };
            var pipeline = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            return pipeline.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            var pipeline = await CreateDefaultEmptyPipeLine(dataFactory, pipelineName);
            Assert.IsNotNull(pipeline);
            Assert.AreEqual(pipelineName, pipeline.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName);
            bool flag = await dataFactory.GetDataFactoryPipelines().ExistsAsync(pipelineName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName);
            var pipeline = await dataFactory.GetDataFactoryPipelines().GetAsync(pipelineName);
            Assert.IsNotNull(pipeline);
            Assert.AreEqual(pipelineName, pipeline.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName);
            var list = await dataFactory.GetDataFactoryPipelines().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            var pipeline = await CreateDefaultEmptyPipeLine(dataFactory, pipelineName);
            bool flag = await dataFactory.GetDataFactoryPipelines().ExistsAsync(pipelineName);
            Assert.IsTrue(flag);

            await pipeline.DeleteAsync(WaitUntil.Completed);
            flag = await dataFactory.GetDataFactoryPipelines().ExistsAsync(pipelineName);
            Assert.IsFalse(flag);
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAzureDatabricksDeltaLakeDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkAzureDatabricksDeltaLake = new DataFactoryLinkedServiceData(new AzureDatabricksDeltaLakeLinkedService(DataFactoryElement<string>.FromSecretString("https://abc-1234567890123456.7.azuredatabricks.net"))
            {
                ClusterId = "123456",
                AccessToken = new DataFactorySecretString("testtoken")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzureDatabricksDeltaLake);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureDatabricksDeltaLakeDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultMongoDbAtlasDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkDataMongoDbAtlas = new DataFactoryLinkedServiceData(new MongoDBAtlasLinkedService(DataFactoryElement<string>.FromSecretString("mongodb+srv://myDatabaseUser:@server.example.com"), "TestDB")
            {
                DriverVersion = "v2"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkDataMongoDbAtlas);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MongoDBAtlasCollectionDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "TestCollection"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultCosmosDbMongoDbDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkCosmosDbMongoDb = new DataFactoryLinkedServiceData(new CosmosDBMongoDBApiLinkedService(DataFactoryElement<string>.FromSecretString("mongodb+srv://myDatabaseUser:@server.example.com"), "TestDB")
            {
                IsServerVersionAbove32 = true
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkCosmosDbMongoDb);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new CosmosDBMongoDBApiCollectionDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "TestCollection"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultMongoDbV2Datasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkMongoDb2 = new DataFactoryLinkedServiceData(new MongoDBV2LinkedService(DataFactoryElement<string>.FromSecretString("mongodb+srv://myDatabaseUser:@server.example.com"), "TestDB"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkMongoDb2);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MongoDBV2CollectionDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "TestCollection"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultMongoDbDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkMongoDb2 = new DataFactoryLinkedServiceData(new MongoDBLinkedService(DataFactoryElement<string>.FromSecretString("mongodb+srv://myDatabaseUser:@server.example.com"), "TestDB"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkMongoDb2);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MongoDBCollectionDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "TestCollection"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSqlServerDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSqlServer = new DataFactoryLinkedServiceData(new SqlServerLinkedService("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSqlServer);

            if (string.IsNullOrEmpty(datasetName))
                return null;

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SqlServerTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSqlDWDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSqlDW = new DataFactoryLinkedServiceData(new AzureSqlDWLinkedService("Server=tcp:myServerAddress.database.windows.net,1433;Database=myDataBase;User ID=myUsername;Password=myPassword;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSqlDW);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureSqlDWTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryLinkedServiceResource> CreateDefaultHDInsightLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData lkHDInsightHive = new DataFactoryLinkedServiceData(new HDInsightLinkedService("https://test.azurehdinsight.net"));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkHDInsightHive);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkBlobSource = new DataFactoryLinkedServiceData(new AzureBlobStorageLinkedService()
            {
                ConnectionString = "DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkBlobSource);

            if (string.IsNullOrEmpty(datasetName))
                return null;

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureBlobDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultWebDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkWebSource = new DataFactoryLinkedServiceData(new WebLinkedService(new WebAnonymousAuthentication("https://www.bing.com/")));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkWebSource);

            DataFactoryDatasetData dsWebSource = new DataFactoryDatasetData(new WebTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), 1));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, dsWebSource);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAmazonRedshiftTableDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkWebSource = new DataFactoryLinkedServiceData(new AmazonRedshiftLinkedService("server", "database"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkWebSource);

            DataFactoryDatasetData dsWebSource = new DataFactoryDatasetData(new AmazonRedshiftTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, dsWebSource);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAzureDataExplorerTableDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkWebSource = new DataFactoryLinkedServiceData(new AzureDataExplorerLinkedService("endpoint", "database"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkWebSource);

            DataFactoryDatasetData dsWebSource = new DataFactoryDatasetData(new AzureDataExplorerTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, dsWebSource);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultOdbcTableDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new OdbcLinkedService(DataFactoryElement<string>.FromSecretString("Driver={ODBC Driver 17 for SQL Server};Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;"))
            {
                UserName = "MyUserName",
                Password = new DataFactorySecretString("fakepassword"),
                Credential = new DataFactorySecretString("fakeCredential"),
                AuthenticationType = "Basic",
                EncryptedCredential = "MyEncryptedCredentials",
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);

            DataFactoryDatasetData dsWebSource = new DataFactoryDatasetData(new OdbcTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, dsWebSource);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultMySqlTableDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkWebSource = new DataFactoryLinkedServiceData(new MySqlLinkedService("server=10.0.0.122;port=3306;database=db;user=https:\\\\test.com;sslmode=1;usesystemtruststore=0"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkWebSource);

            DataFactoryDatasetData dsWebSource = new DataFactoryDatasetData(new MySqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, dsWebSource);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSybaseTableDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkWebSource = new DataFactoryLinkedServiceData(new SybaseLinkedService("server", "database"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkWebSource);

            DataFactoryDatasetData dsWebSource = new DataFactoryDatasetData(new SybaseTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, dsWebSource);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultODataResourceDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkWebSource = new DataFactoryLinkedServiceData(new ODataLinkedService("http:\\test.com"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkWebSource);

            DataFactoryDatasetData dsWebSource = new DataFactoryDatasetData(new ODataResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, dsWebSource);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultOracleTableDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkWebSource = new DataFactoryLinkedServiceData(new OracleLinkedService("host=test123.com;port=232;sid=12321231;user id=https:\\\\test.com"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkWebSource);

            DataFactoryDatasetData dsWebSource = new DataFactoryDatasetData(new OracleTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, dsWebSource);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAzureSqlDatabaseDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSqlSource = new DataFactoryLinkedServiceData(new AzureSqlDatabaseLinkedService("Server=tcp:myServerAddress.database.windows.net,1433;Database=myDataBase;User ID=myUsername;Password=myPassword;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSqlSource);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAmazonRdsForSqlServerDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkAmazonRdsForSqlServer = new DataFactoryLinkedServiceData(new AmazonRdsForSqlServerLinkedService("integrated security=False;data source=TestServer;initial catalog=TestDB;user id=ais;Password=myPassword;"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAmazonRdsForSqlServer);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AmazonRdsForSqlServerTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultFileSystemDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkFileSystem = new DataFactoryLinkedServiceData(new FileServerLinkedService("\\testmachine\\testfolder"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkFileSystem);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new XmlDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAzureDataLakeStoreDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkAzureDataLakeStore = new DataFactoryLinkedServiceData(new AzureDataLakeStoreLinkedService("https://test.azuredatalakestore.net/testindex/v1"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzureDataLakeStore);

            if (string.IsNullOrEmpty(datasetName))
                return null;

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureDataLakeStoreDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultHttpDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkHttp = new DataFactoryLinkedServiceData(new HttpLinkedService("https://www.bing.com/"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkHttp);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new XmlDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAzureSearchDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkAzureSearch = new DataFactoryLinkedServiceData(new AzureSearchLinkedService("https://test-test.search.windows.net"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzureSearch);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureSearchIndexDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "testindenx"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultHdfsLinkedService(DataFactoryResource dataFactory, string linkedServiceName, string datasetName = "")
        {
            DataFactoryLinkedServiceData lkHdfs = new DataFactoryLinkedServiceData(new HdfsLinkedService("10.10.10.10"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkHdfs);
            if (string.IsNullOrEmpty(datasetName))
            {
                return null;
            }

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryLinkedServiceResource> CreateDefaultAzureKeyVaultLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData lkAzureKeyVault = new DataFactoryLinkedServiceData(new AzureKeyVaultLinkedService("https://Test.vault.azure.net/"));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzureKeyVault);
            return result.Value;
        }

        private async Task<DataFactoryLinkedServiceResource> CreateDefaultAzureBatchLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, "linkedService_AzureBlobStorage", null);
            DataFactoryLinkedServiceData lkAzureBatch = new DataFactoryLinkedServiceData(new AzureBatchLinkedService("test", "https://testaccount.westus.batch.azure.com", "testpool", new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, "linkedService_AzureBlobStorage")));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzureBatch);
            return result.Value;
        }

        private async Task<DataFactoryLinkedServiceResource> CreateDefaultAzureMLLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData lkAzureBatch = new DataFactoryLinkedServiceData(new AzureMLLinkedService("https://testendpoint/jobs", new DataFactorySecretString("testapikey")));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzureBatch);
            return result.Value;
        }

        private async Task<DataFactoryLinkedServiceResource> CreateDefaultAzureMLServiceLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData lkAzureBatch = new DataFactoryLinkedServiceData(new AzureMLServiceLinkedService("12345678-1234-1234-1234-123456789012", "groupname", "workspacename"));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzureBatch);
            return result.Value;
        }

        private async Task<DataFactoryLinkedServiceResource> CreateDefaultAzureDataLakeAnalyticsLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData lkAzureBatch = new DataFactoryLinkedServiceData(new AzureDataLakeAnalyticsLinkedService("testaccount", "12345678-1234-1234-1234-123456789012"));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzureBatch);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAzureMySqlDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkAzureBatch = new DataFactoryLinkedServiceData(new AzureMySqlLinkedService("server=test.mysql.database.azure.com;port=3306;database=TestDB;uid=admin;pwd=fakePassword;sslmode=1;usesystemtruststore=0"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzureBatch);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureMySqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSalesforceDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSalesforce = new DataFactoryLinkedServiceData(new SalesforceLinkedService()
            {
                EnvironmentUri = "https://login.salesforce.com",
                Username = "admin",
                ApiVersion = "54.0",
                Password = new DataFactorySecretString("fakePassword"),
                SecurityToken = new DataFactorySecretString("fakeToken")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSalesforce);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SalesforceObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDynamics365Datasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkDynamics365 = new DataFactoryLinkedServiceData(new DynamicsLinkedService("Online", "AADServicePrincipal")
            {
                ServiceUri = "https://testorganization.crm.dynamics.com",
                ServicePrincipalId = "fakeServicePrincipalId",
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalCredential = new DataFactorySecretString("fakeServicePrincipalKey")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkDynamics365);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SalesforceObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSapCloudForCustomerDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSapCloudForCustomer = new DataFactoryLinkedServiceData(new SapCloudForCustomerLinkedService("www.fakeuri.com")
            {
                Username = "fakeUsername",
                Password = new DataFactorySecretString("fakePassword")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSapCloudForCustomer);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SapCloudForCustomerResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fakePath"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSapBWDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSapCloudForCustomer = new DataFactoryLinkedServiceData(new SapBWLinkedService("fakeServer", "123456", "fakeClientId"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSapCloudForCustomer);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SapBWCubeDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAmazonMWSDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkAmazonMWS = new DataFactoryLinkedServiceData(new AmazonMwsLinkedService("mws.amazonservice.com", "fakeMarketplaceId", "fakeSellerId", "fakeAccessKeyId"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAmazonMWS);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AmazonMwsObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAzurePostgreSqlDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkAzurePostgreSql = new DataFactoryLinkedServiceData(new AzurePostgreSqlLinkedService()
            {
                ConnectionString = "host=test.postgres.database.azure.com;port=5432;database=testdb;uid=fakeuid;pwd=fakePassword;encryptionmethod=0"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzurePostgreSql);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzurePostgreSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAmazonRdsForOracleTableDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkAmazonRds = new DataFactoryLinkedServiceData(new AmazonRdsForOracleLinkedService(DataFactoryElement<string>.FromSecretString("fakeConnString"))
            {
                ConnectionString = "host=test.fakeserver.database.azure.com;port=5432;database=testdb;uid=fakeuid;pwd=fakePassword;encryptionmethod=0"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAmazonRds);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AmazonRdsForOracleTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultConcurDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkConcur = new DataFactoryLinkedServiceData(new ConcurLinkedService("fakeClientId", "fakeUsername"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkConcur);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ConcurObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultCouchbaseDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkCouchbase = new DataFactoryLinkedServiceData(new CouchbaseLinkedService()
            {
                ConnectionString = "server=testserver;port=1563;authmech=1"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkCouchbase);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new CouchbaseTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)) { TableName = "fakeTableName" });
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDrillDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkDrill = new DataFactoryLinkedServiceData(new DrillLinkedService()
            {
                ConnectionString = "ConnectionType=Direct;Host=10.10.10.10;Port=1234;AuthenticationType=No Authentication"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkDrill);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DrillTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultEloquaDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkEloqua = new DataFactoryLinkedServiceData(new EloquaLinkedService("fakeendpoing.eloqua.com", "fakeUserName")
            {
                Password = new DataFactorySecretString("fakePassword")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkEloqua);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new EloquaObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultGoogleBigQueryDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkGoogleBigQuery = new DataFactoryLinkedServiceData(new GoogleBigQueryLinkedService("fakeProjectId", "UserAuthentication")
            {
                RequestGoogleDriveScope = false,
                ClientId = "fakeClientId",
                ClientSecret = new DataFactorySecretString("fakeClientSecret")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkGoogleBigQuery);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new GoogleBigQueryObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultGreenplumDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkGreenplum = new DataFactoryLinkedServiceData(new GreenplumLinkedService()
            {
                ConnectionString = "host=10.10.10.10;port=1234;db=TestDB;uid=fakeUsername;password=fakePasswordZ"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkGreenplum);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new GreenplumTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultHbaseDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkHbase = new DataFactoryLinkedServiceData(new HBaseLinkedService("192.168.222.160", "Anonymous"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkHbase);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new HBaseObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultHiveDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkHive = new DataFactoryLinkedServiceData(new HiveLinkedService("192.168.222.160", "Anonymous"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkHive);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new HiveObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultHubspotDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkHubspot = new DataFactoryLinkedServiceData(new HubspotLinkedService("fakeClientId"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkHubspot);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new HubspotObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultImpalaDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkImpala = new DataFactoryLinkedServiceData(new ImpalaLinkedService("192.168.222.160", "Anonymous"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkImpala);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new HubspotObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultJiraDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkJira = new DataFactoryLinkedServiceData(new JiraLinkedService("jira.example.com", "skroob"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkJira);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new JiraObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultMagentoDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkMagento = new DataFactoryLinkedServiceData(new MagentoLinkedService("192.168.222.110/magento3"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkMagento);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MagentoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultMariaDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkMaria = new DataFactoryLinkedServiceData(new MariaDBLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("SecureString")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkMaria);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MariaDBTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAzureMariaDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkAzureMaria = new DataFactoryLinkedServiceData(new AzureMariaDBLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("SecureString")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzureMaria);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureMariaDBTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultMarketoDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkMarketo = new DataFactoryLinkedServiceData(new MarketoLinkedService("123-ABC-321.mktorest.com", "fakeClientId"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkMarketo);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MarketoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultPaypalDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkPaypal = new DataFactoryLinkedServiceData(new PaypalLinkedService("api.sandbox.paypal.com", "fakeClientId"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkPaypal);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new PaypalObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultPhoenixDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkPhoenix = new DataFactoryLinkedServiceData(new PhoenixLinkedService("192.168.222.160", "Anonymous"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkPhoenix);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new PhoenixObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultPrestoDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkPresto = new DataFactoryLinkedServiceData(new PrestoLinkedService("192.168.222.160", "0.148-t", "test", "Anonymous"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkPresto);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new PrestoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultQuickBooksDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkQuickBooks = new DataFactoryLinkedServiceData(new QuickBooksLinkedService()
            {
                Endpoint = "quickbooks.api.intuit.com",
                ConsumerSecret = new DataFactorySecretString("fakeConsumerSecret"),
                CompanyId = "fakeCompanyId",
                ConsumerKey = "fakeConsumerKey",
                AccessToken = new DataFactorySecretString("fakeAccessToken"),
                AccessTokenSecret = new DataFactorySecretString("fakeAccessTokenSecret"),
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkQuickBooks);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new QuickBooksObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultServiceNowDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkQuickBooks = new DataFactoryLinkedServiceData(new ServiceNowLinkedService("http://instance.service-now.com", "Basic")
            {
                Username = "admin",
                Password = new DataFactorySecretString("fakePassword")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkQuickBooks);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ServiceNowObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultShopifyDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkShopify = new DataFactoryLinkedServiceData(new ShopifyLinkedService("mystore.myshopify.com")
            {
                AccessToken = new DataFactorySecretString("fakeAccessToken")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkShopify);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ShopifyObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSparkDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSpark = new DataFactoryLinkedServiceData(new SparkLinkedService("myserver", 443, "WindowsAzureHDInsightService")
            {
                Username = "admin",
                Password = new DataFactorySecretString("fakePassword")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSpark);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SparkObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSquareDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSquare = new DataFactoryLinkedServiceData(new SquareLinkedService()
            {
                Host = "mystore.mysquare.com",
                ClientId = "fakeClientId",
                ClientSecret = new DataFactorySecretString("fakeClientSecret"),
                RedirectUri = "http://localhost:2500"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSquare);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SquareObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultXeroDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkXero = new DataFactoryLinkedServiceData(new XeroLinkedService()
            {
                Host = "api.xero.com",
                ConsumerKey = new DataFactorySecretString("fakeConsumerKey"),
                PrivateKey = new DataFactorySecretString("fakeClientSecret")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkXero);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new XeroObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultZohoDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkZoho = new DataFactoryLinkedServiceData(new ZohoLinkedService()
            {
                Endpoint = "crm.zoho.com/crm/private",
                AccessToken = new DataFactorySecretString("fakeAccessToken")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkZoho);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ZohoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSapECCDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkZoho = new DataFactoryLinkedServiceData(new SapEccLinkedService("fakeUrl")
            {
                Username = "admin",
                Password = new DataFactorySecretString("fakePassword")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkZoho);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ZohoObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDynamicsAXDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkZoho = new DataFactoryLinkedServiceData(new DynamicsAXLinkedService("https://testorganization.ax.dynamics.com/data", "fakeServicePrincipalId", new DataFactorySecretString("fakeServicePrincipalKey"), "fakeTenantId", "fakeAddResourceId"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkZoho);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DynamicsAXResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fakeTestPath"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultNetezzaDatasets(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkNetezza = new DataFactoryLinkedServiceData(new NetezzaLinkedService()
            {
                ConnectionString = "server=testserver;port=1234;database=TestDB;uid=admin;password=fakePassword;securitylevel=preferredUnSecured"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkNetezza);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new NetezzaTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultVerticaDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkVertica = new DataFactoryLinkedServiceData(new VerticaLinkedService()
            {
                ConnectionString = "server=testserver;port=1234;database=TestDB;uid=admin;password=fakePassword;"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkVertica);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new VerticaTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryLinkedServiceResource> CreateDefaultDatabricksLinkedService(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkVertica = new DataFactoryLinkedServiceData(new AzureDatabricksLinkedService("fakeDomain"));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkVertica);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSapOpenHubDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSapOpenHub = new DataFactoryLinkedServiceData(new SapOpenHubLinkedService()
            {
                UserName = "admin",
                Server = "fakeServer",
                SystemNumber = "12",
                ClientId = "1"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSapOpenHub);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SapOpenHubTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fakeName"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSapTableDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSapOpenHub = new DataFactoryLinkedServiceData(new SapTableLinkedService()
            {
                ClientId = "1",
                SncMode = "false",
                UserName = "admin",
                Server = "testserver",
                Password = new DataFactorySecretString("fakePassword")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSapOpenHub);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SapTableResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fakeName"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDb2Dataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkDb2 = new DataFactoryLinkedServiceData(new Db2LinkedService()
            {
                ConnectionString = "server=testserver;database=TestDB;username=tests;authenticationtype=Basic"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkDb2);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new Db2TableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAvroDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceName, null);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AvroDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultExcelDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceName, null);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new ExcelDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultOrcDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceName, null);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new OrcDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForADLS(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceName, null);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForABS(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceName, null);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForFS(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkFileSystem = new DataFactoryLinkedServiceData(new FileServerLinkedService("\\testmachine\\testfolder"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkFileSystem);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForFTP(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkFTP = new DataFactoryLinkedServiceData(new FtpServerLinkedService("10.10.10.10")
            {
                AuthenticationType = FtpAuthenticationType.Anonymous
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkFTP);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForBlobFS(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkAzureBlobFS = new DataFactoryLinkedServiceData(new AzureBlobFSLinkedService()
            {
                Uri = "https://test.dfs.core.windows.net/",
                Tenant = "fakeTenant",
                ServicePrincipalId = "fakeServicePrincipalId",
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalCredential = new DataFactorySecretString("fakeServicePrincipalCredential")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzureBlobFS);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureBlobFSDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForHdfs(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkHdfs = new DataFactoryLinkedServiceData(new HdfsLinkedService("10.10.10.10"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkHdfs);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForHttp(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkHttp = new DataFactoryLinkedServiceData(new HttpLinkedService("https://www.bing.com/"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkHttp);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForAmazonS3(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkAmazonS3 = new DataFactoryLinkedServiceData(new AmazonS3LinkedService()
            {
                ServiceUri = "https://s3.amazonaws.com",
                AccessKeyId = "fakeAccessKeyId",
                AuthenticationType = "AccessKey",
                SecretAccessKey = new DataFactorySecretString("fakeSecretAccessKey")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAmazonS3);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForSftp(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSftp = new DataFactoryLinkedServiceData(new SftpServerLinkedService("10.10.10.10"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSftp);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForGoogleCloud(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSftp = new DataFactoryLinkedServiceData(new GoogleCloudStorageLinkedService()
            {
                ServiceUri = "https://storage.googleapis.com",
                AccessKeyId = "fakeAccessKeyId",
                SecretAccessKey = new DataFactorySecretString("fakeSecretAccessKey")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSftp);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForAmazonS3Compatible(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSftp = new DataFactoryLinkedServiceData(new AmazonS3CompatibleLinkedService()
            {
                ServiceUri = "https://storage.googleapis.com",
                AccessKeyId = "fakeAccessKeyId",
                SecretAccessKey = new DataFactorySecretString("fakeSecretAccessKey")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSftp);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForOracleCloud(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSftp = new DataFactoryLinkedServiceData(new OracleCloudStorageLinkedService()
            {
                ServiceUri = "https://fakeServer.compat.objectstorage.1.oraclecloud.com",
                AccessKeyId = "fakeAccessKeyId",
                SecretAccessKey = new DataFactorySecretString("fakeSecretAccessKey")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSftp);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultDelimitedTextDatasetForAzureFile(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSftp = new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
            {
                ConnectionString = "DefaultEndpointsProtocol=https;AccountName=adftestbeijing;EndpointSuffix=core.windows.net;"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSftp);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new DelimitedTextDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultCosmosDbApiDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkCosmosDb = new DataFactoryLinkedServiceData(new CosmosDBMongoDBApiLinkedService(DataFactoryElement<string>.FromSecretString("mongodb+srv://myDatabaseUser:@server.example.com"), "TestDB")
            {
                IsServerVersionAbove32 = true
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkCosmosDb);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new CosmosDBSqlApiCollectionDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fakeCollectionName"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultJsonDatasetForAzureBlobStorage(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceName, null);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new JsonDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultJsonDatasetForAzureDataLakeStorage(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceName, null);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new JsonDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultXmlDatasetForAzureBlobStorage(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceName, null);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new XmlDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultBinaryDatasetForAzureDataLakeStorage(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceName, null);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new BinaryDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultBinaryDatasetForAzureBlobStorage(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceName, null);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new BinaryDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultBinaryDatasetForAzureBlobFS(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkBinary = new DataFactoryLinkedServiceData(new AzureBlobFSLinkedService()
            {
                Uri = "https://test.dfs.core.windows.net/",
                Tenant = "fakeTenant",
                ServicePrincipalId = "fakeServicePrincipalId",
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalCredential = new DataFactorySecretString("fakeServicePrincipalCredential")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkBinary);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new BinaryDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultBinaryDatasetForFS(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkBinary = new DataFactoryLinkedServiceData(new FileServerLinkedService("\\testmachine\\testfolder"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkBinary);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new BinaryDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultBinaryDatasetForSftp(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkBinary = new DataFactoryLinkedServiceData(new SftpServerLinkedService("10.10.10.10"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkBinary);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new BinaryDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultTeradataDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkTeradata = new DataFactoryLinkedServiceData(new TeradataLinkedService()
            {
                ConnectionString = "dbcname=testserver;uid=fakekey;password=fakePassword"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkTeradata);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new TeradataTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSqlMIDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSqlMI = new DataFactoryLinkedServiceData(new AzureSqlMILinkedService("integrated security=False;encrypt=True;connection timeout=30;data source=test-sqlmi.public.123456789012.database.windows.net,3342;initial catalog=TestDB;user id=fakekey"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSqlMI);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureSqlMITableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSapHanaDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSqlMI = new DataFactoryLinkedServiceData(new SapHanaLinkedService()
            {
                ConnectionString = "servernode=10.10.10.10;uid=fakeaccesskeyid",
                Password = new DataFactorySecretString("fakePassword")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSqlMI);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SapHanaTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSalesforceServiceCloudDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSalesforceServiceCloud = new DataFactoryLinkedServiceData(new SalesforceServiceCloudLinkedService()
            {
                EnvironmentUri = "https://login.salesforce.com",
                Username = "fakeUsername",
                SecurityToken = new DataFactorySecretString("fakeSecurityToken"),
                ApiVersion = "54.0"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSalesforceServiceCloud);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SalesforceServiceCloudObjectDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultCommonDataServiceForAppsDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkCommonDataServiceForApps = new DataFactoryLinkedServiceData(new CommonDataServiceForAppsLinkedService("Online", "ServicePrincipalKey")
            {
                ServiceUri = "https://test.crm.dynamics.com",
                ServicePrincipalId = "fakeServicePrincipalId",
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalCredential = new DataFactorySecretString("fakeServicePrincipalCredential")
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkCommonDataServiceForApps);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new CommonDataServiceForAppsEntityDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultInformixDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkInformix = new DataFactoryLinkedServiceData(new InformixLinkedService("Database=TestDB;Host=192.168.10.10;Server=db_engine_tcp;Service=1492;Protocol=onsoctcp;UID=fakeUsername;Password=fakePassword;"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkInformix);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new InformixTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultMicrosoftAccessDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkMicrosoftAccess = new DataFactoryLinkedServiceData(new MicrosoftAccessLinkedService("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\myFolder\\myAccessFile.accdb;Persist Security Info=False;"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkMicrosoftAccess);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new MicrosoftAccessTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultSharePointOnlineListDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkMicrosoftAccess = new DataFactoryLinkedServiceData(new SharePointOnlineListLinkedService("10.10.10.10", "fakeTenantId", "fakeServicePrincipalId", new DataFactorySecretString("fakeServicePrincipalKey")));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkMicrosoftAccess);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new SharePointOnlineListResourceDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultOffice365Dataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkMicrosoftAccess = new DataFactoryLinkedServiceData(new Office365LinkedService("fakeTenantId", "fakeServicePrincipalTenantId", "fakeServicePrincipalId", new DataFactorySecretString("fakeServicePrincipalKey")));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkMicrosoftAccess);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new Office365Dataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fakeTableName"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultCassandraSourceDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkCassandraSource = new DataFactoryLinkedServiceData(new CassandraLinkedService("10.10.10.10"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkCassandraSource);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new CassandraTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAzureTableStorageDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkCassandraSource = new DataFactoryLinkedServiceData(new AzureTableStorageLinkedService()
            {
                ConnectionString = "DefaultEndpointsProtocol=https;AccountName=fakeServer;EndpointSuffix=core.windows.net;"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkCassandraSource);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName), "fakeTable"));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task<DataFactoryIntegrationRuntimeResource> CreateDefaultManagedIntegrationRuntime(DataFactoryResource dataFactory, string integrationRuntimeName)
        {
            ManagedIntegrationRuntime properties = new ManagedIntegrationRuntime()
            {
                ComputeProperties = new IntegrationRuntimeComputeProperties()
                {
                    Location = "eastus2",
                    DataFlowProperties = new IntegrationRuntimeDataFlowProperties()
                    {
                        ComputeType = DataFlowComputeType.General,
                        CoreCount = 4,
                        TimeToLiveInMinutes = 10
                    }
                }
            };
            DataFactoryIntegrationRuntimeData data = new DataFactoryIntegrationRuntimeData(properties);
            var integrationRuntime = await dataFactory.GetDataFactoryIntegrationRuntimes().CreateOrUpdateAsync(WaitUntil.Completed, integrationRuntimeName, data);
            return integrationRuntime.Value;
        }

        private async Task<DataFactoryIntegrationRuntimeResource> CreateDefaultAzureSSISIntegrationRuntime(DataFactoryResource dataFactory, string integrationRuntimeName)
        {
            ManagedIntegrationRuntime properties = new ManagedIntegrationRuntime()
            {
                ComputeProperties = new IntegrationRuntimeComputeProperties()
                {
                    Location = "eastus2",
                    NodeSize = "Standard_D2_v3",
                    NumberOfNodes = 2,
                    MaxParallelExecutionsPerNode = 2
                },
                SsisProperties = new IntegrationRuntimeSsisProperties()
                {
                    CatalogInfo = new IntegrationRuntimeSsisCatalogInfo()
                    {
                        CatalogServerEndpoint = "fakeServer.database.windows.net",
                        CatalogAdminUserName = "fakeUsername",
                        CatalogAdminPassword = new DataFactorySecretString("fakePassword"),
                        CatalogPricingTier = "S1"
                    },
                    Edition = "Standard",
                    LicenseType = "LicenseIncluded"
                }
            };
            DataFactoryIntegrationRuntimeData data = new DataFactoryIntegrationRuntimeData(properties);
            var integrationRuntime = await dataFactory.GetDataFactoryIntegrationRuntimes().CreateOrUpdateAsync(WaitUntil.Completed, integrationRuntimeName, data);
            return integrationRuntime.Value;
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AzureDatabricksDeltaLake()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceName = Recording.GenerateAssetName("linkedService_");
            string datasetName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureDatabricksDeltaLakeDatasets(dataFactory, linkedServiceName, datasetName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CopyActivitySource(),new CopySink())
                    {
                        Source = new AzureDatabricksDeltaLakeSource()
                        {
                            Query = "abc",
                            ExportSettings = new AzureDatabricksDeltaLakeExportCommand()
                            {
                                DateFormat = "xxx",
                                TimestampFormat = "xxx"
                            }
                        },
                        Sink = new AzureDatabricksDeltaLakeSink()
                        {
                            PreCopyScript = "abc",
                            ImportSettings = new AzureDatabricksDeltaLakeImportCommand()
                            {
                                DateFormat = "xxx",
                                TimestampFormat = "xxx"
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_MongoDbAtlas_CosmosDbMongoDbApi()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultMongoDbAtlasDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultCosmosDbMongoDbDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CopyActivitySource(),new CopySink())
                    {
                        Source = new MongoDBAtlasSource()
                        {
                            Filter = DataFactoryElement<string>.FromExpression("@dataset().MyFilter"),
                            CursorMethods = new MongoDBCursorMethodsProperties()
                            {
                                Sort = "{ age : 1 }",
                                Skip = 3,
                                Limit = 10,
                                Project = DataFactoryElement<string>.FromExpression("@dataset().MyProject")
                            },
                            BatchSize = 5
                        },
                        Sink = new CosmosDBMongoDBApiSink()
                        {
                            WriteBehavior = "upsert",
                            WriteBatchSize = 5000
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    },
                },
                Parameters =
                {
                    ["MyFilter"] = new EntityParameterSpecification(EntityParameterType.String),
                    ["MyProject"] = new EntityParameterSpecification(EntityParameterType.String)
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_MongoDbAtlas_MongoDbV2()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultMongoDbAtlasDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultMongoDbV2Datasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CopyActivitySource(),new CopySink())
                    {
                        Source = new MongoDBAtlasSource()
                        {
                            Filter = DataFactoryElement<string>.FromExpression("@dataset().MyFilter"),
                            CursorMethods = new MongoDBCursorMethodsProperties()
                            {
                                Sort = "{ age : 1 }",
                                Skip = 3,
                                Limit = 10,
                                Project = DataFactoryElement<string>.FromExpression("@dataset().MyProject")
                            },
                            BatchSize = 5
                        },
                        Sink = new MongoDBV2Sink()
                        {
                            WriteBehavior = "upsert",
                            WriteBatchSize = 5000
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    },
                },
                Parameters =
                {
                    ["MyFilter"] = new EntityParameterSpecification(EntityParameterType.String),
                    ["MyProject"] = new EntityParameterSpecification(EntityParameterType.String)
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SqlService_SqlDW()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceStagingName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSqlServerDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultSqlDWDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceStagingName, null);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CopyActivitySource(),new CopySink())
                    {
                        Source = new SqlSource()
                        {
                        },
                        Sink = new SqlDWSink()
                        {
                            AllowPolyBase = true,
                            WriteBatchSize = 5,
                            WriteBatchTimeout = "PT0S"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        EnableStaging = true,
                        StagingSettings = new StagingSettings(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceStagingName))
                    },
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_HDInsightHive()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultHDInsightLinkedService(dataFactory, linkedServiceSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new HDInsightHiveActivity(taskName)
                    {
                        ScriptPath = "testing",
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DataFactoryBlobSource(),new DataFactoryBlobSink())
                    {
                        Source = new DataFactoryBlobSource()
                        {
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    },
                    new CopyActivity(taskName + "1",new DataFactoryBlobSource(),new DataFactoryBlobSink())
                    {
                        Source = new DataFactoryBlobSource()
                        {
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        DependsOn =
                        {
                            new PipelineActivityDependency(taskName,new List<DependencyCondition>() { DependencyCondition.Succeeded})
                        }
                    },
                    new CopyActivity(taskName + "1",new DataFactoryBlobSource(),new DataFactoryBlobSink())
                    {
                        Source = new DataFactoryBlobSource()
                        {
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        DependsOn =
                        {
                            new PipelineActivityDependency(taskName + "1",new List<DependencyCondition>()
                            {
                                DependencyCondition.Succeeded,
                                DependencyCondition.Skipped,
                                DependencyCondition.Failed,
                                DependencyCondition.Completed
                            })
                        }
                    }
                },
                Parameters =
                {
                    ["OutputBlobName"] = new EntityParameterSpecification(EntityParameterType.String),
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Blob_Expression()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CopyActivitySource(),new CopySink())
                    {
                        Source = new DataFactoryBlobSource()
                        {
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                            {
                                Parameters =
                                {
                                    new KeyValuePair<string, BinaryData>("FileName",BinaryData.FromString("{\"value\": \"@concat(\\\"variant0_0_\\\", parameters(\\\"OutputBlobName\\\"))\",\"type\": \"Expression\"}"))
                                }
                            }
                        }
                    },
                    new CopyActivity(taskName + "1",new CopyActivitySource(),new CopySink())
                    {
                        Source = new DataFactoryBlobSource()
                        {
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                            {
                                Parameters =
                                {
                                    new KeyValuePair<string, BinaryData>("FileName",BinaryData.FromString("{\"value\": \"@concat(\\\"variant0_0_\\\", parameters(\\\"OutputBlobName\\\"))\",\"type\": \"Expression\"}"))
                                }
                            }
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                            {
                                Parameters =
                                {
                                    new KeyValuePair<string, BinaryData>("FileName",BinaryData.FromString("{\"value\": \"@concat(\\\"variant0_0_\\\", parameters(\\\"OutputBlobName\\\"))\",\"type\": \"Expression\"}"))
                                }
                            }
                        },
                        DependsOn =
                        {
                            new PipelineActivityDependency(taskName,new List<DependencyCondition>() { DependencyCondition.Succeeded})
                        }
                    },
                    new CopyActivity(taskName + "1",new CopyActivitySource(),new CopySink())
                    {
                        Source = new DataFactoryBlobSource()
                        {
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                            {
                                Parameters =
                                {
                                    new KeyValuePair<string, BinaryData>("FileName",BinaryData.FromString("{\"value\": \"@concat(\\\"variant0_0_\\\", parameters(\\\"OutputBlobName\\\"))\",\"type\": \"Expression\"}"))
                                }
                            }
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                            {
                                Parameters =
                                {
                                    new KeyValuePair<string, BinaryData>("FileName",BinaryData.FromString("{\"value\": \"@concat(\\\"variant0_0_\\\", parameters(\\\"OutputBlobName\\\"))\",\"type\": \"Expression\"}"))
                                }
                            }
                        },
                        DependsOn =
                        {
                            new PipelineActivityDependency(taskName + "1",new List<DependencyCondition>()
                            {
                                DependencyCondition.Succeeded,
                                DependencyCondition.Skipped,
                                DependencyCondition.Failed,
                                DependencyCondition.Completed
                            })
                        }
                    }
                },
                Parameters =
                {
                    new KeyValuePair<string, EntityParameterSpecification>("OutputBlobName",new EntityParameterSpecification(EntityParameterType.String))
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Web_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultWebDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CopyActivitySource(),new CopySink())
                    {
                        Source = new WebSource()
                        {
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SqlServerStoredProcedure()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultSqlServerDatasets(dataFactory, linkedServiceSourceName, null);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new SqlServerStoredProcedureActivity(taskName,"testStoredProcedure")
                    {
                        StoredProcedureParameters = BinaryData.FromString("{\"para1\" : \"test\"}"),
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AzureSql_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CopyActivitySource(),new CopySink())
                    {
                        Source = new AzureSqlSource()
                        {
                            SqlReaderQuery = "SELECT TOP 1 * FROM DBO.TestTable",
                            PartitionOption = BinaryData.FromString("\"DynamicRange\""),
                            PartitionSettings = new SqlPartitionSettings()
                            {
                                PartitionColumnName = "partitionColumnName",
                                PartitionUpperBound = "10",
                                PartitionLowerBound = "1"
                            }
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00",
                            BlobWriterAddHeader = true
                        },
                        Translator = BinaryData.FromString("{\"type\": \"TabularTranslator\",\"columnMappings\": \"PartitionKey:PartitionKey\"}"),
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                },
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SqlServer_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CopyActivitySource(),new CopySink())
                    {
                        Source = new SqlSource()
                        {
                            SourceRetryCount = 2,
                            SourceRetryWait = "00:00:01",
                            SqlReaderQuery = "$EncryptedString$MyEncryptedQuery",
                            SqlReaderStoredProcedureName = "CopyTestSrcStoredProcedureWithParameters",
                            StoredProcedureParameters = BinaryData.FromString("{\"stringData\": {\"value\": \"test\",\"type\": \"String\"},\"id\": {\"value\": \"3\",\"type\": \"Int\"}}"),
                            IsolationLevel = "ReadCommitted"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            BlobWriterAddHeader = true,
                            WriteBatchSize = 100000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Translator = BinaryData.FromString("{\"type\": \"TabularTranslator\",\"columnMappings\": \"PartitionKey:PartitionKey\"}"),
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    },
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AmazonRdsFOrSqlServer_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAmazonRdsForSqlServerDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CopyActivitySource(),new CopySink())
                    {
                        Source = new AmazonRdsForSqlServerSource()
                        {
                            SourceRetryCount = 2,
                            SourceRetryWait = "00:00:01",
                            SqlReaderQuery = "$EncryptedString$MyEncryptedQuery",
                            SqlReaderStoredProcedureName = "CopyTestSrcStoredProcedureWithParameters",
                            StoredProcedureParameters = BinaryData.FromString("{\"stringData\": {\"value\": \"test\",\"type\": \"String\"},\"id\": {\"value\": \"3\",\"type\": \"Int\"}}"),
                            IsolationLevel = "ReadCommitted"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            BlobWriterAddHeader = true,
                            WriteBatchSize = 100000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Translator = BinaryData.FromString("{\"type\": \"TabularTranslator\",\"columnMappings\": \"PartitionKey:PartitionKey\"}"),
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    },
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Relational_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSqlServerDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new RelationalSource(),new DataFactoryBlobSink())
                    {
                        Source = new RelationalSource()
                        {
                            Query = "select * from northwind_mysql.orders"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            BlobWriterAddHeader = true,
                            WriteBatchSize = 100000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    },
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_HDInsightPig()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultHDInsightLinkedService(dataFactory, linkedServiceSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new HDInsightPigActivity(taskName)
                    {
                        ScriptPath = "scripts/script.pig",
                        ScriptLinkedService = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        StorageLinkedServices =
                        {
                            new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSinkName)
                        },
                        Defines =
                        {
                            new KeyValuePair<string, BinaryData>("PropertyBagPropertyName1",BinaryData.FromString("\"PropertyBagValue1\""))
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_HDInsightHive_StorageLinkedService()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName2 = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultHDInsightLinkedService(dataFactory, linkedServiceSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, null);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName2, null);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new HDInsightHiveActivity(taskName)
                    {
                        ScriptPath = "scripts/script.hql",
                        ScriptLinkedService = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        StorageLinkedServices =
                        {
                            new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSinkName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_HDInsightMapReduce()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultHDInsightLinkedService(dataFactory, linkedServiceSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, null);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new HDInsightMapReduceActivity(taskName,"MYClass","TestData/hadoop-mapreduce-examples.jar")
                    {
                        JarLinkedService = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSinkName),
                        Arguments =
                        {
                            BinaryData.FromString("\"wasb:///example/data/gutenberg/davinci.txt\"")
                        },
                        JarLibs =
                        {
                            BinaryData.FromString("\"TestData/test1.jar\"")
                        },
                        StorageLinkedServices =
                        {
                            new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSinkName)
                        },
                        Defines =
                        {
                            new KeyValuePair<string, BinaryData>("PropertyBagPropertyName1",BinaryData.FromString("\"PropertyBagValue1\""))
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_HDInsightSpark()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultHDInsightLinkedService(dataFactory, linkedServiceSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, null);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new HDInsightSparkActivity(taskName,"release\\1.0","main.py")
                    {
                        SparkJobLinkedService = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        ClassName = "main",
                        Arguments =
                        {
                            BinaryData.FromString("\"arg1\""),
                            BinaryData.FromString("\"arg2\"")
                        },
                        SparkConfig =
                        {
                            new KeyValuePair<string, BinaryData>("spark.yarn.appMasterEnv.PYSPARK_DRIVER_PYTHON",BinaryData.FromString("\"python3\""))
                        },
                        ProxyUser = "user1"
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Cassandra_AzureTable()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultCassandraSourceDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureTableStorageDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CopyActivitySource(), new AzureTableSink())
                    {
                        Source = new CassandraSource()
                        {
                            Query = "select * from table",
                            ConsistencyLevel = "TWO"
                        },
                        Sink = new AzureTableSink()
                        {
                            WriteBatchSize = 100000,
                            AzureTableDefaultPartitionKeyValue = "defaultParitionKey"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_MongoDb_AzureBlob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultMongoDbDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new MongoDBSource(), new DataFactoryBlobSink())
                    {
                        Source= new MongoDBSource()
                        {
                            Query = "select * from collection"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SqlServer_Blob_StoredProcedure()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSqlServerDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SqlServerSource(), new DataFactoryBlobSink())
                    {
                        Source= new SqlServerSource()
                        {
                            SourceRetryCount = 2,
                            SourceRetryWait = "00:00:01",
                            SqlReaderQuery = "$EncryptedString$MyEncryptedQuery",
                            SqlReaderStoredProcedureName = "$EncryptedString$MyEncryptedQuery",
                            StoredProcedureParameters = BinaryData.FromString("{\"stringData\": { \"value\": \"tr3\" },\"id\": {\"value\": \"$$MediaTypeNames.Text.Format(\\\"{0:yyyy}\\\", SliceStart)\",\"type\": \"Int\"}}")
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00",
                            BlobWriterAddHeader = true,
                            CopyBehavior = BinaryData.FromString("\"PreserveHierarchy\"")
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Blob_FileSystem()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultFileSystemDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName, new DataFactoryBlobSource(), new FileSystemSink())
                    {
                        Source = new DataFactoryBlobSource()
                        {
                            SourceRetryCount = 2,
                            SourceRetryWait = "00:00:01",
                            TreatEmptyAsNull = true
                        },
                        Sink = new FileSystemSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSourceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AzureSqlServer_SqlServer()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultSqlServerDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName, new AzureTableSource(), new SqlSink())
                    {
                        Source = new AzureTableSource()
                        {
                            SourceRetryCount = 2,
                            SourceRetryWait = "00:00:01",
                            AzureTableSourceQuery = "$$Text.Format(\"PartitionKey eq \\\\\"ContosoSampleDevice\\\\\" and RowKey eq \\\\\"{0:yyyy-MM-ddTHH:mm:ss.fffffffZ}!{1:yyyy-MM-ddTHH:mm:ss.fffffffZ}\\\\\"\", Time.AddMinutes(SliceStart, -10), Time.AddMinutes(SliceStart, -9))",
                            AzureTableSourceIgnoreTableNotFound = false
                        },
                        Sink = new SqlSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00",
                            SinkRetryCount = 3,
                            SinkRetryWait = "00:00:01",
                            SqlWriterStoredProcedureName = "MySprocName",
                            SqlWriterTableType = "MyTableType"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSourceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Blob_AzureQueue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName, new DataFactoryBlobSource(), new AzureQueueSink())
                    {
                        Source = new DataFactoryBlobSource()
                        {
                            SourceRetryCount = 2,
                            SourceRetryWait = "00:00:01",
                            TreatEmptyAsNull = false
                        },
                        Sink = new AzureQueueSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00",
                            SinkRetryCount = 3,
                            SinkRetryWait = "00:00:01"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSourceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SqlDW_SqlDW_StoredProcedure()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSqlDWDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultSqlDWDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName, new SqlDWSource(), new SqlDWSink())
                    {
                        Source = new SqlDWSource()
                        {
                            SqlReaderQuery = "$EncryptedString$MyEncryptedQuery",
                            SqlReaderStoredProcedureName = "CopyTestSrcStoredProcedureWithParameters",
                            StoredProcedureParameters = BinaryData.FromString("{\"stringData\": {\"value\": \"test\",\"type\": \"String\"},\"id\": {\"value\": \"3\",\"type\": \"Int\"}}"),
                        },
                        Sink = new SqlDWSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00",
                            AllowPolyBase = true,
                            PolyBaseSettings = new PolybaseSettings()
                            {
                                RejectType = "percentage",
                                RejectValue = 20,
                                RejectSampleValue = 80,
                                UseTypeDefault = true
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SqlDW_SqlDW()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSqlDWDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultSqlDWDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName, new SqlDWSource(), new SqlDWSink())
                    {
                        Source = new SqlDWSource()
                        {
                            SqlReaderQuery = "$EncryptedString$MyEncryptedQuery",
                        },
                        Sink = new SqlDWSink()
                        {
                            PreCopyScript = "script",
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AzureDataLakeStore()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName, new AzureDataLakeStoreSource(), new AzureDataLakeStoreSink())
                    {
                        Source = new AzureDataLakeStoreSource()
                        {
                        },
                        Sink = new AzureDataLakeStoreSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Http_AzureSearchIndex()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultHttpDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureSearchDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName, new DataFactoryHttpFileSource(), new AzureSearchIndexSink())
                    {
                        Source = new DataFactoryHttpFileSource()
                        {
                            HttpRequestTimeout = "01:00:00"
                        },
                        Sink = new AzureSearchIndexSink()
                        {
                            WriteBehavior = "Upload"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_HDInsightStreaming()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultHDInsightLinkedService(dataFactory, linkedServiceSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new HDInsightStreamingActivity(taskName,"cat.exe","wc.exe","example/data/gutenberg/davinci.txt","example/data/StreamingOutput/wc.txt",new List<BinaryData>() { {BinaryData.FromString("\"aureleu/example/apps/wc.exe\"") }, { BinaryData.FromString("\"aureleu/example/apps/cat.exe\"") } })
                    {
                        Defines =
                        {
                            new KeyValuePair<string, BinaryData>("PropertyBagPropertyName1",BinaryData.FromString("\"PropertyBagValue1\""))
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        FileLinkedService = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSinkName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 1,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_FileSystem()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultFileSystemDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultFileSystemDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new FileSystemSource(),new FileSystemSink())
                    {
                        Source = new FileSystemSource()
                        {
                            Recursive = false
                        },
                        Sink = new FileSystemSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00",
                            CopyBehavior = "FlattenHierarchy"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSourceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Blob_AzureTable()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureTableStorageDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DataFactoryBlobSource(),new AzureTableSink())
                    {
                        Source = new DataFactoryBlobSource()
                        {
                        },
                        Sink = new AzureTableSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00",
                            AzureTableDefaultPartitionKeyValue = "defaultParitionKey"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSourceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_FileSystem_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultFileSystemDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new FileSystemSource(),new DataFactoryBlobSink())
                    {
                        Source = new FileSystemSource()
                        {
                            Recursive = true
                        },
                        Sink = new FileSystemSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00",
                            CopyBehavior = "FlattenHierarchy"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSourceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Hdfs_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultHdfsLinkedService(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new HdfsSource(),new DataFactoryBlobSink())
                    {
                        Source = new HdfsSource()
                        {
                            DistcpSettings = new DistcpSettings("fakeEndpoint","fakePath")
                            {
                                DistcpOptions = "fakeOptions"
                            }
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00",
                            CopyBehavior = BinaryData.FromString("\"FlattenHierarchy\"")
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference, datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSourceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Lookup_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new LookupActivity(taskName,new DataFactoryBlobSource(),new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName))
                    {
                        FirstRowOnly = false
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Lookup_SqlServer()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultSqlServerDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new LookupActivity(taskName,new SqlServerSource(),new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName))
                    {
                        Source = new SqlServerSource()
                        {
                            SqlReaderQuery = "select * from MyTable"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Lookup_AzureSqlServer()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSourceName, datasetSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new LookupActivity(taskName,new AzureTableSource(),new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName))
                    {
                        Source = new AzureTableSource()
                        {
                            AzureTableSourceQuery = "PartitionKey eq \"SomePartition\""
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Lookup_FileSystem()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultFileSystemDataset(dataFactory, linkedServiceSourceName, datasetSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new LookupActivity(taskName,new FileSystemSource(),new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName))
                    {
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_GetMetadata_AzureSqlServer()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSourceName, datasetSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new GetDatasetMetadataActivity(taskName,new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName))
                    {
                        FieldList =
                        {
                            BinaryData.FromString("\"columnCount\""),
                                    BinaryData.FromString("\"exists\"")
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Web()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new WebActivity(taskName,WebActivityMethod.Get,"http://www.bing.com")
                    {
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Web_Authentication()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new WebActivity(taskName,WebActivityMethod.Get,"http://www.bing.com")
                    {
                        Authentication = new WebActivityAuthentication()
                        {
                            WebActivityAuthenticationType = "Basic",
                            Username = "testuser",
                            Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),"testsecret")
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Custom()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName1 = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName2 = Recording.GenerateAssetName("linkedService_");
            string datasetSinkName1 = Recording.GenerateAssetName("dataset_");
            string datasetSinkName2 = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureBatchLinkedService(dataFactory, linkedServiceSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName1, datasetSinkName1);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName2, datasetSinkName2);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CustomActivity(taskName,"Echo Hello World!")
                    {
                        FolderPath = "TestFolder",
                        ResourceLinkedService = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSinkName1),
                        ReferenceObjects = new CustomActivityReferenceObject()
                        {
                            LinkedServices =
                            {
                                new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSinkName2)
                            },
                            Datasets =
                            {
                                new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName1),
                                new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName2)
                            }
                        },
                        ExtendedProperties =
                        {
                            new KeyValuePair<string, BinaryData>("PropertyBagPropertyName1",BinaryData.FromString("\"PropertyBagValue1\"")),
                            new KeyValuePair<string, BinaryData>("propertyBagPropertyName2",BinaryData.FromString("\"PropertyBagValue2\"")),
                            new KeyValuePair<string, BinaryData>("dateTime1",BinaryData.FromString("\"2015-04-12T12:13:14Z\"")),
                        },
                        RetentionTimeInDays = BinaryData.FromString("35"),
                        AutoUserSpecification = "pooladmin",
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceSourceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_IfCondition()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSourceName, datasetSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new IfConditionActivity(taskName,new DataFactoryExpression(DataFactoryExpressionType.Expression,"TestExpression"))
                    {
                        IfTrueActivities =
                        {
                            new GetDatasetMetadataActivity(taskName,new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName))
                            {
                                FieldList =
                                {
                                    BinaryData.FromString("\"columnCount\""),
                                    BinaryData.FromString("\"exists\"")
                                }
                            }
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Switch()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSourceName, datasetSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new SwitchActivity(taskName,new DataFactoryExpression(DataFactoryExpressionType.Expression,"TestExpression"))
                    {
                        Cases =
                        {
                            new SwitchCaseActivity()
                            {
                                Value = "Case1",
                                Activities =
                                {
                                    new GetDatasetMetadataActivity(taskName,new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName))
                                    {
                                        FieldList =
                                        {
                                            BinaryData.FromString("\"columnCount\""),
                                            BinaryData.FromString("\"exists\"")
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Foreach()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSourceName, datasetSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new ForEachActivity(taskName,new DataFactoryExpression(DataFactoryExpressionType.Expression,"TestExpression"),new List<PipelineActivity>()
                    {
                        new GetDatasetMetadataActivity(taskName,new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName))
                        {
                            FieldList =
                            {
                                BinaryData.FromString("\"columnCount\""),
                                BinaryData.FromString("\"exists\"")
                            }
                        }
                    })
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Until()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string untilTaskName = Recording.GenerateAssetName("task-");
            string getMetadataTaskName = Recording.GenerateAssetName("task-");
            string waitTaskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSourceName, datasetSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new UntilActivity(untilTaskName,new DataFactoryExpression(DataFactoryExpressionType.Expression,"@bool(equals(activity(\"MyActivity\").status, \"Succeeded\"))"),new List<PipelineActivity>()
                    {
                        new GetDatasetMetadataActivity(getMetadataTaskName,new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName))
                        {
                            FieldList =
                            {
                                BinaryData.FromString("\"columnCount\""),
                                BinaryData.FromString("\"exists\"")
                            }
                        },
                        new WaitActivity(waitTaskName,30)
                    })
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AzureMLUpdateResource()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string azureMLTaskName = Recording.GenerateAssetName("task-");
            string azureMLLinkedServiceName = Recording.GenerateAssetName("linkedService_");
            string azureBlobStorageLinkedService = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultAzureMLLinkedService(dataFactory, azureMLLinkedServiceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, azureBlobStorageLinkedService, null);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new AzureMLUpdateResourceActivity(azureMLTaskName,"Training Exp for ADF ML TiP tests[trained model]",new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,azureBlobStorageLinkedService),"azuremltesting/testInput.ilearner")
                    {
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,azureMLLinkedServiceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AzureMLBatchExecution()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string azureMLServiceTaskName = Recording.GenerateAssetName("task-");
            string azureMLServiceLinkedServiceName = Recording.GenerateAssetName("linkedService_");
            string azureBlobStorageLinkedService = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultAzureMLServiceLinkedService(dataFactory, azureMLServiceLinkedServiceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, azureBlobStorageLinkedService, null);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new AzureMLBatchExecutionActivity(azureMLServiceTaskName)
                    {
                        WebServiceInputs =
                        {
                            new KeyValuePair<string, AzureMLWebServiceFile>("input1",new AzureMLWebServiceFile("azuremltesting/IrisInput/Two Class Data.1.arff",new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,azureBlobStorageLinkedService)))
                        },
                        WebServiceOutputs =
                        {
                            new KeyValuePair<string, AzureMLWebServiceFile>("output1",new AzureMLWebServiceFile("azuremltesting/categorized/##folderPath##/result.csv",new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,azureBlobStorageLinkedService)))
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,azureMLServiceLinkedServiceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DataLakeAnalyticsUSQL()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string azureDataLakeAnalyticsTaskName = Recording.GenerateAssetName("task-");
            string azureDataLakeAnalyticsLinkedServiceName = Recording.GenerateAssetName("linkedService_");
            string azureBlobStorageLinkedService = Recording.GenerateAssetName("linkedService_");

            await CreateDefaultAzureDataLakeAnalyticsLinkedService(dataFactory, azureDataLakeAnalyticsLinkedServiceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, azureBlobStorageLinkedService, null);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new DataLakeAnalyticsUsqlActivity(azureDataLakeAnalyticsTaskName,"fakepath",new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,azureBlobStorageLinkedService))
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AzureMySql_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureMySqlDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new AzureMySqlSource(),new DataFactoryBlobSink())
                    {
                        Source = new AzureMySqlSource()
                        {
                            Query = "select * from azuremysqltable"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Salesforce_Salesforce()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSalesforceDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultSalesforceDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SalesforceSource(),new SalesforceSink())
                    {
                        Source = new SalesforceSource()
                        {
                            Query = "select Id from table",
                            ReadBehavior = "QueryAll"
                        },
                        Sink = new SalesforceSink()
                        {
                            WriteBehavior = "Insert",
                            IgnoreNullValues = false
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Dynamics_Dynamics()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDynamics365Datasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDynamics365Datasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DynamicsSource(),new DynamicsSink("Upsert"))
                    {
                        Source = new DynamicsSource()
                        {
                            Query = "fetchXml query"
                        },
                        Sink = new DynamicsSink("Upsert")
                        {
                            AlternateKeyName = "keyName",
                            IgnoreNullValues = false
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SAPCloudForCustomer_AzureDataLakeStore()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSapCloudForCustomerDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SapCloudForCustomerSource(),new AzureDataLakeStoreSink())
                    {
                        Source = new SapCloudForCustomerSource()
                        {
                            Query = "$select=Column0",
                            HttpRequestTimeout = "00:05:00"
                        },
                        Sink = new AzureDataLakeStoreSink()
                        {
                            CopyBehavior = "FlattenHierarchy"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AmazonMWS_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAmazonMWSDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new AmazonMwsSource(),new DataFactoryBlobSink())
                    {
                        Source = new AmazonMwsSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AzurePostgreSql_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzurePostgreSqlDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new AzurePostgreSqlSource(),new DataFactoryBlobSink())
                    {
                        Source = new AzurePostgreSqlSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Concur_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultConcurDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new ConcurSource(),new DataFactoryBlobSink())
                    {
                        Source = new ConcurSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Couchbase_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultCouchbaseDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CouchbaseSource(),new DataFactoryBlobSink())
                    {
                        Source = new ConcurSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Drill_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDrillDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DrillSource(),new DataFactoryBlobSink())
                    {
                        Source = new DrillSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Eloqua_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultEloquaDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new EloquaSource(),new DataFactoryBlobSink())
                    {
                        Source = new EloquaSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_GoogleBigQuery_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultGoogleBigQueryDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new GoogleBigQuerySource(),new DataFactoryBlobSink())
                    {
                        Source = new GoogleBigQuerySource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Greenplum_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultGreenplumDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new GreenplumSource(),new DataFactoryBlobSink())
                    {
                        Source = new GreenplumSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_HBase_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultHbaseDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new HBaseSource(),new DataFactoryBlobSink())
                    {
                        Source = new HBaseSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Hive_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultHiveDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new HiveSource(),new DataFactoryBlobSink())
                    {
                        Source = new HiveSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Hubspot_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultHubspotDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new HubspotSource(),new DataFactoryBlobSink())
                    {
                        Source = new HubspotSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Impala_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultImpalaDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new ImpalaSource(),new DataFactoryBlobSink())
                    {
                        Source = new ImpalaSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Jira_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultJiraDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new JiraSource(),new DataFactoryBlobSink())
                    {
                        Source = new JiraSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Magento_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultMagentoDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new MagentoSource(),new DataFactoryBlobSink())
                    {
                        Source = new MagentoSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_MariaDB_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultMariaDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new MariaDBSource(),new DataFactoryBlobSink())
                    {
                        Source = new MariaDBSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AzureMariaDB_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureMariaDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new AzureMariaDBSource(),new DataFactoryBlobSink())
                    {
                        Source = new AzureMariaDBSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Marketo_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultMarketoDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new MarketoSource(),new DataFactoryBlobSink())
                    {
                        Source = new MarketoSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Paypal_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultPaypalDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new PaypalSource(),new DataFactoryBlobSink())
                    {
                        Source = new PaypalSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Phoenix_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultPhoenixDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new PhoenixSource(),new DataFactoryBlobSink())
                    {
                        Source = new PhoenixSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Presto_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultPrestoDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new PrestoSource(),new DataFactoryBlobSink())
                    {
                        Source = new PrestoSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_QuickBooks_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultQuickBooksDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new QuickBooksSource(),new DataFactoryBlobSink())
                    {
                        Source = new QuickBooksSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_ServiceNow_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultServiceNowDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new ServiceNowSource(),new DataFactoryBlobSink())
                    {
                        Source = new ServiceNowSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Shopify_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultShopifyDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new ShopifySource(),new DataFactoryBlobSink())
                    {
                        Source = new ShopifySource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Spark_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSparkDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SparkSource(),new DataFactoryBlobSink())
                    {
                        Source = new SparkSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Square_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSquareDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SquareSource(),new DataFactoryBlobSink())
                    {
                        Source = new SquareSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Xero_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultXeroDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new XeroSource(),new DataFactoryBlobSink())
                    {
                        Source = new XeroSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Zoho_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultZohoDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new ZohoSource(),new DataFactoryBlobSink())
                    {
                        Source = new ZohoSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SAPECC_AzureDataLakeStore()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSapECCDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SapEccSource(),new AzureDataLakeStoreSink())
                    {
                        Source = new SapEccSource()
                        {
                            Query = "$top=1",
                            HttpRequestTimeout = "00:05:00"
                        },
                        Sink = new AzureDataLakeStoreSink()
                        {
                            CopyBehavior = "FlattenHierarchy"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DynamicsAX_AzureDataLakeStore()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDynamicsAXDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DynamicsAXSource(),new AzureDataLakeStoreSink())
                    {
                        Source = new DynamicsAXSource()
                        {
                            Query = "$top=1",
                            HttpRequestTimeout = "00:05:00"
                        },
                        Sink = new AzureDataLakeStoreSink()
                        {
                            CopyBehavior = "FlattenHierarchy"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Netezza_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultNetezzaDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new NetezzaSource(),new AzureDataLakeStoreSink())
                    {
                        Source = new NetezzaSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Vertica_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultVerticaDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new VerticaSource(),new AzureDataLakeStoreSink())
                    {
                        Source = new VerticaSource()
                        {
                            Query = "select * from a table"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Databricks()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDatabricksLinkedService(dataFactory, linkedServiceSourceName, datasetSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new DatabricksNotebookActivity(taskName,"/testing")
                    {
                        BaseParameters =
                        {
                            new KeyValuePair<string, BinaryData>("test",BinaryData.FromString("\"test\""))
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Blob_UserProperties()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DataFactoryBlobSource(),new DataFactoryBlobSink())
                    {
                        Source = new DataFactoryBlobSource()
                        {
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        UserProperties =
                        {
                            new PipelineActivityUserProperty("File","@item().File")
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Blob_UserProperties_Empty()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DataFactoryBlobSource(),new DataFactoryBlobSink())
                    {
                        Source = new DataFactoryBlobSource()
                        {
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        UserProperties =
                        {
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SapOpenHub_AzureDataLakeStore()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSapOpenHubDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SapOpenHubSource(),new AzureDataLakeStoreSink())
                    {
                        Source = new SapOpenHubSource()
                        {
                            ExcludeLastRequest = false,
                            BaseRequestId = 123,
                            CustomRfcReadTableFunctionModule = "fakecustomRfcReadTableFunctionModule",
                            SapDataColumnDelimiter = "|"
                        },
                        Sink = new AzureDataLakeStoreSink()
                        {
                            CopyBehavior = "FlattenHierarchy"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_WebHook()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSapOpenHubDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new WebHookActivity(taskName,new WebHookActivityMethod("get"),"http://www.bing.com")
                    {
                        Authentication = new WebActivityAuthentication()
                        {
                            Username = "testuser",
                            Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSinkName),"pfxpwd")
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Validation()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new ValidationActivity(taskName,new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName))
                    {
                        Timeout = "00:03:00",
                        Sleep = 10,
                        MinimumSize = DataFactoryElement<int>.FromExpression("@add(0,1)")
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SapTable_AzureDataLakeStore()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSapTableDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SapTableSource(),new AzureDataLakeStoreSink())
                    {
                        Source = new SapTableSource()
                        {
                            RowCount = 3
                        },
                        Sink = new AzureDataLakeStoreSink()
                        {
                            CopyBehavior = "FlattenHierarchy"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Avro_Settings()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAvroDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAvroDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new AvroSource(),new AvroSink())
                    {
                        Source = new AvroSource()
                        {
                            StoreSettings = new AzureDataLakeStoreReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true
                            }
                        },
                        Sink = new AvroSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new AvroWriteSettings()
                            {
                                RecordName = "testavro",
                                RecordNamespace = "microsoft.datatransfer.test"
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Excel_Settings()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultExcelDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAvroDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new ExcelSource(),new AvroSink())
                    {
                        Source = new ExcelSource()
                        {
                            StoreSettings = new AzureDataLakeStoreReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true
                            }
                        },
                        Sink = new AvroSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new AvroWriteSettings()
                            {
                                RecordName = "testavro",
                                RecordNamespace = "microsoft.datatransfer.test"
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Orc_Settings()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultOrcDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultOrcDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new OrcSource(),new OrcSink())
                    {
                        Source = new OrcSource()
                        {
                            StoreSettings = new AzureDataLakeStoreReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true
                            }
                        },
                        Sink = new OrcSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_Settings_LogStorageSettings()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new AzureDataLakeStoreReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("\\N",BinaryData.FromString("\"NULL\""))
                                }
                            },
                            AdditionalColumns = BinaryData.FromObjectAsJson<List<KeyValuePair<string,BinaryData>>>(new List<KeyValuePair<string, BinaryData>>()
                            {
                                new KeyValuePair<string, BinaryData>("name",BinaryData.FromString("\"clmn\"")),
                                new KeyValuePair<string, BinaryData>("value",BinaryData.FromString("\"$$FILEPATH\"")),
                            })
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true,
                                MaxRowsPerFile = 10,
                                FileNamePrefix = "orcSinkFile"
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        ValidateDataConsistency = true,
                        SkipErrorFile = new SkipErrorFile(true,true),
                        LogStorageSettings = new LogStorageSettings(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName))
                        {
                            Path = "test",
                            LogLevel = "exampleLogLevel",
                            EnableReliableLogging = true
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_Settings_LogSettings()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new AzureDataLakeStoreReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("\\N",BinaryData.FromString("\"NULL\""))
                                }
                            },
                            AdditionalColumns = BinaryData.FromObjectAsJson<List<KeyValuePair<string,BinaryData>>>(new List<KeyValuePair<string, BinaryData>>()
                            {
                                new KeyValuePair<string, BinaryData>("name",BinaryData.FromString("\"clmn\"")),
                                new KeyValuePair<string, BinaryData>("value",BinaryData.FromString("\"$$FILEPATH\"")),
                            })
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true,
                                MaxRowsPerFile = 10,
                                FileNamePrefix = "orcSinkFile"
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        ValidateDataConsistency = true,
                        SkipErrorFile = new SkipErrorFile(true,true),
                        LogSettings = new DataFactoryLogSettings(new LogLocationSettings(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName))
                        {
                            Path = "test"
                        })
                        {
                            EnableCopyActivityLog = true,
                            CopyActivityLogSettings = new CopyActivityLogSettings()
                            {
                                LogLevel = "Info",
                                EnableReliableLogging = true
                            }
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_UnZip_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceNameABS = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkNameADLS = Recording.GenerateAssetName("linkedService_");
            string datasetSourceNameABS = Recording.GenerateAssetName("dataset_");
            string datasetSinkNameADLS = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForABS(dataFactory, linkedServiceSourceNameABS, datasetSourceNameABS);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkNameADLS, datasetSinkNameADLS);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new AzureBlobStorageReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true,
                                PartitionRootPath = "abc/",
                                WildcardFolderPath = "abc/efg",
                                WildcardFileName = "test.csv"
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("\\N",BinaryData.FromString("\"NULL\""))
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceNameABS)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkNameADLS)
                        }
                    },
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new AzureBlobStorageReadSettings()
                            {
                                Recursive = true
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                CompressionProperties = new ZipDeflateReadSettings()
                                {
                                    PreserveZipFileNameAsFolder = false
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureBlobStorageWriteSettings()
                            {
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".txt")
                            {
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceNameABS)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkNameADLS)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_AzureBlobFS_AzureDataLakeStorage()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForBlobFS(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new AzureBlobFSReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true,
                                ModifiedDatetimeStart = "2019-07-02T00:00:00.000Z",
                                ModifiedDatetimeEnd = "2019-07-03T00:00:00.000Z"
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("\\N",BinaryData.FromString("\"NULL\""))
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_FileSystem_AzureDataLakeStorage()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForFS(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new FileServerReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true,
                                WildcardFolderPath = "A*",
                                ModifiedDatetimeStart = "2019-07-02T00:00:00.000Z",
                                ModifiedDatetimeEnd = "2019-07-03T00:00:00.000Z",
                                FileFilter = "*.log"
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("\\N",BinaryData.FromString("\"NULL\""))
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_FTPServer_AzureDataLakeStorage()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForFTP(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new FtpReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true,
                                WildcardFolderPath = "A*",
                                WildcardFileName = "*.csv",
                                UseBinaryTransfer = true,
                                DisableChunking = true
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("\\N",BinaryData.FromString("\"NULL\""))
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_Hdfs_AzureDataLakeStorage()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForHdfs(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new HdfsReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true,
                                WildcardFolderPath = "A*",
                                WildcardFileName = "*.csv",
                                ModifiedDatetimeStart = "2019-07-02T00:00:00.000Z",
                                ModifiedDatetimeEnd = "2019-07-03T00:00:00.000Z",
                                DeleteFilesAfterCompletion = true
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("\\N",BinaryData.FromString("\"NULL\""))
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior ="PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_Http_AzureDataLakeStorage()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForHttp(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new HttpReadSettings()
                            {
                                RequestMethod = "POST",
                                RequestBody = "request body",
                                AdditionalHeaders = "testHeaders",
                                RequestTimeout = "2400"
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("\\N",BinaryData.FromString("\"NULL\""))
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_AmazonS3_AzureDataLakeStorage()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForAmazonS3(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new AmazonS3ReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true,
                                Prefix = "A*",
                                ModifiedDatetimeStart = "2019-07-02T00:00:00.000Z",
                                ModifiedDatetimeEnd = "2019-07-03T00:00:00.000Z"
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("\\N",BinaryData.FromString("\"NULL\""))
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_SftpServer_AzureDataLakeStorage()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForSftp(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new SftpReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true,
                                WildcardFileName = "*.csv",
                                WildcardFolderPath = "A*",
                                ModifiedDatetimeStart = "2019-07-02T00:00:00.000Z",
                                ModifiedDatetimeEnd = "2019-07-03T00:00:00.000Z"
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("\\N",BinaryData.FromString("\"NULL\""))
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_CosmosDbSqlApi()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultCosmosDbApiDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultCosmosDbApiDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CosmosDBSqlApiSource(),new CosmosDBSqlApiSink())
                    {
                        Source = new CosmosDBSqlApiSource()
                        {
                            Query = "select * from c",
                            PageSize = 1000,
                            PreferredRegions = new List<string>()
                            {
                                "West US",
                                "West US 2"
                            }
                        },
                        Sink = new CosmosDBSqlApiSink()
                        {
                            WriteBatchSize = 1000,
                            WriteBehavior = "upsert"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Json()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceBlobSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");
            string datasetBlobSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultJsonDatasetForAzureBlobStorage(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultJsonDatasetForAzureBlobStorage(dataFactory, linkedServiceSinkName, datasetSinkName);
            await CreateDefaultDelimitedTextDatasetForABS(dataFactory, linkedServiceBlobSinkName, datasetBlobSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new JsonSource(),new JsonSink())
                    {
                        Source = new JsonSource()
                        {
                            StoreSettings = new AzureBlobStorageReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true,
                                WildcardFolderPath = "abc*d",
                                WildcardFileName = "*.json"
                            }
                        },
                        Sink = new JsonSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new JsonWriteSettings()
                            {
                                FilePattern = "arrayOfObjects"
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    },
                    new CopyActivity(taskName + "1",new JsonSource(),new JsonSink())
                    {
                        Source = new JsonSource()
                        {
                            StoreSettings = new AzureBlobStorageReadSettings()
                            {
                                Recursive = true
                            },
                            FormatSettings = new JsonReadSettings()
                            {
                                CompressionProperties = new ZipDeflateReadSettings()
                                {
                                    PreserveZipFileNameAsFolder = false
                                }
                            },
                            AdditionalColumns = BinaryData.FromObjectAsJson<List<KeyValuePair<string,BinaryData>>>(new List<KeyValuePair<string, BinaryData>>()
                            {
                                new KeyValuePair<string, BinaryData>("name",BinaryData.FromString("\"clmn\"")),
                                new KeyValuePair<string, BinaryData>("value",BinaryData.FromString("\"$$FILEPATH\"")),
                            })
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureBlobStorageWriteSettings()
                            {
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".txt")
                            {
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetBlobSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Xml()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceBlobSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");
            string datasetBlobSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultXmlDatasetForAzureBlobStorage(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultJsonDatasetForAzureDataLakeStorage(dataFactory, linkedServiceSinkName, datasetSinkName);
            await CreateDefaultDelimitedTextDatasetForABS(dataFactory, linkedServiceBlobSinkName, datasetBlobSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new XmlSource(),new JsonSink())
                    {
                        Source = new XmlSource()
                        {
                            StoreSettings = new AzureBlobStorageReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true,
                                WildcardFolderPath = "abc*d",
                                WildcardFileName = "*.xml"
                            },
                            FormatSettings = new XmlReadSettings()
                            {
                                ValidationMode = "xsd"
                            }
                        },
                        Sink = new JsonSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new JsonWriteSettings()
                            {
                                FilePattern = "arrayOfObjects"
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    },
                    new CopyActivity(taskName + "1",new XmlSource(),new DelimitedTextSink())
                    {
                        Source = new XmlSource()
                        {
                            StoreSettings = new AzureBlobStorageReadSettings()
                            {
                                Recursive = true
                            },
                            FormatSettings = new XmlReadSettings()
                            {
                                CompressionProperties = new ZipDeflateReadSettings()
                                {
                                    PreserveZipFileNameAsFolder = false
                                }
                            },
                            AdditionalColumns = BinaryData.FromObjectAsJson<List<KeyValuePair<string,BinaryData>>>(new List<KeyValuePair<string, BinaryData>>()
                            {
                                new KeyValuePair<string, BinaryData>("name",BinaryData.FromString("\"clmn\"")),
                                new KeyValuePair<string, BinaryData>("value",BinaryData.FromString("\"$$FILEPATH\"")),
                            })
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureBlobStorageWriteSettings()
                            {
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".txt")
                            {
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetBlobSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Binary()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceBlobSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceBlobSinkName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceBlobFSSinkName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceFSSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSftpSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetBlobSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");
            string datasetBlobSinkName = Recording.GenerateAssetName("dataset_");
            string datasetBlobFSSinkName = Recording.GenerateAssetName("dataset_");
            string datasetFSSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSftpSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultBinaryDatasetForAzureDataLakeStorage(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultBinaryDatasetForAzureDataLakeStorage(dataFactory, linkedServiceSinkName, datasetSinkName);
            await CreateDefaultBinaryDatasetForAzureBlobStorage(dataFactory, linkedServiceBlobSinkName, datasetBlobSinkName);
            await CreateDefaultBinaryDatasetForAzureBlobStorage(dataFactory, linkedServiceBlobSourceName, datasetBlobSourceName);
            await CreateDefaultBinaryDatasetForAzureBlobFS(dataFactory, linkedServiceBlobFSSinkName, datasetBlobFSSinkName);
            await CreateDefaultBinaryDatasetForFS(dataFactory, linkedServiceFSSourceName, datasetFSSourceName);
            await CreateDefaultBinaryDatasetForSftp(dataFactory, linkedServiceSftpSinkName, datasetSftpSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new BinarySource(),new BinarySink())
                    {
                        Source = new BinarySource()
                        {
                            StoreSettings = new AzureDataLakeStoreReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true,
                                FileListPath = "test.txt"
                            }
                        },
                        Sink = new BinarySink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy",
                                ExpiryDateTime = "2018-12-01T05:00:00Z"
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    },
                    new CopyActivity(taskName,new BinarySource(),new BinarySink())
                    {
                        Source = new BinarySource()
                        {
                            StoreSettings = new AzureDataLakeStoreReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true
                            }
                        },
                        Sink = new BinarySink()
                        {
                            StoreSettings = new AzureBlobStorageWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy",
                                BlockSizeInMB = 8
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetBlobSinkName)
                        }
                    },
                    new CopyActivity(taskName,new BinarySource(),new BinarySink())
                    {
                        Source = new BinarySource()
                        {
                            StoreSettings = new AzureDataLakeStoreReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true
                            }
                        },
                        Sink = new BinarySink()
                        {
                            StoreSettings = new AzureBlobFSWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy",
                                BlockSizeInMB = 8
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetBlobFSSinkName)
                        }
                    },
                    new CopyActivity(taskName,new BinarySource(),new BinarySink())
                    {
                        Source = new BinarySource()
                        {
                            StoreSettings = new AzureBlobStorageReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true,
                                Prefix = "test"
                            }
                        },
                        Sink = new BinarySink()
                        {
                            StoreSettings = new AzureBlobStorageWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy",
                                BlockSizeInMB = 8
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetBlobSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetBlobSinkName)
                        }
                    },
                    new CopyActivity(taskName,new BinarySource(),new BinarySink())
                    {
                        Source = new BinarySource()
                        {
                            StoreSettings = new FileServerReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true
                            },
                            FormatSettings = new BinaryReadSettings()
                            {
                                CompressionProperties = new ZipDeflateReadSettings()
                                {
                                    PreserveZipFileNameAsFolder = false,
                                }
                            }
                        },
                        Sink = new BinarySink()
                        {
                            StoreSettings = new SftpWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy",
                                OperationTimeout = "01:00:00",
                                UseTempFileRename = false
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetFSSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSftpSinkName)
                        }
                    },
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Teradata_Binary()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultTeradataDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultBinaryDatasetForAzureDataLakeStorage(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new TeradataSource(),new BinarySink())
                    {
                        Source = new TeradataSource()
                        {
                            PartitionOption = DataFactoryElement<string>.FromExpression("\"pipeline().parameters.parallelOption\"")
                        },
                        Sink = new BinarySink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                },
                Parameters =
                {
                    new KeyValuePair<string, EntityParameterSpecification>("parallelOption",new EntityParameterSpecification(EntityParameterType.String))
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SqlMI()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSqlMIDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultSqlMIDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SqlMISource(),new SqlMISink())
                    {
                        Source = new SqlMISource()
                        {
                            SqlReaderQuery = "select * from my_table",
                            QueryTimeout = "00:00:05"
                        },
                        Sink = new SqlMISink()
                        {
                            SqlWriterTableType = "MarketingType",
                            SqlWriterStoredProcedureName = "spOverwriteMarketing",
                            StoredProcedureParameters = BinaryData.FromObjectAsJson<KeyValuePair<string,BinaryData>>(new KeyValuePair<string, BinaryData>("category",BinaryData.FromString("\"{\"Value\":\"ProductA\"}\"")))
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SalesforceServiceCloud()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSalesforceServiceCloudDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultSalesforceServiceCloudDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SalesforceServiceCloudSource(),new SalesforceServiceCloudSink())
                    {
                        Source = new SalesforceServiceCloudSource()
                        {
                            Query = "select * from my_table",
                            ReadBehavior = "QueryAll"
                        },
                        Sink = new SalesforceServiceCloudSink()
                        {
                            WriteBehavior = "Upsert"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_CommonDataServiceForApps()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultCommonDataServiceForAppsDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultCommonDataServiceForAppsDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new CommonDataServiceForAppsSource(),new CommonDataServiceForAppsSink("Upsert"))
                    {
                        Source = new CommonDataServiceForAppsSource()
                        {
                            Query = "FetchXML"
                        },
                        Sink = new CommonDataServiceForAppsSink("Upsert")
                        {
                            WriteBatchSize = 5000,
                            IgnoreNullValues = true,
                            AlternateKeyName = "keyName"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Informix()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultInformixDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultInformixDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new InformixSource(),new InformixSink())
                    {
                        Source = new InformixSource()
                        {
                            Query = "fake_query"
                        },
                        Sink = new InformixSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_MicrosoftAccess()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultMicrosoftAccessDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultMicrosoftAccessDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new MicrosoftAccessSource(),new MicrosoftAccessSink())
                    {
                        Source = new MicrosoftAccessSource()
                        {
                            Query = "fake_query"
                        },
                        Sink = new MicrosoftAccessSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SapTable_AzureDataLakeStorage()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSapTableDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SapTableSource(),new AzureDataLakeStoreSink())
                    {
                        Source = new SapTableSource()
                        {
                            RowCount = 3,
                            SapDataColumnDelimiter = "|",
                            PartitionOption = BinaryData.FromString("\"pipeline().parameters.parallelOption\""),
                            PartitionSettings = new SapTablePartitionSettings()
                            {
                                PartitionColumnName = "fakeColumn",
                                PartitionUpperBound = "20190405",
                                PartitionLowerBound = "20170809",
                                MaxPartitionsNumber = 3
                            }
                        },
                        Sink = new AzureDataLakeStoreSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    }
                },
                Parameters =
                {
                    new KeyValuePair<string, EntityParameterSpecification>("parallelOption",new EntityParameterSpecification(EntityParameterType.String))
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Db2_AzurePostgreSql()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");
            await CreateDefaultDb2Dataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzurePostgreSqlDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new Db2Source(),new AzurePostgreSqlSink())
                     {
                          Source = new Db2Source()
                          {
                              Query = "select * from faketable"
                          },
                          Sink = new AzurePostgreSqlSink()
                          {
                              PreCopyScript = "fake script"
                          },
                          Inputs =
                          {
                              new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                          },
                          Outputs =
                          {
                              new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                          },
                          Policy = new PipelineActivityPolicy()
                          {
                              Retry = 2,
                              Timeout = "01:00:00"
                          }
                     }
                }
            };
            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AmazonRdsForOracle_AzurePostgreSql()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAmazonRdsForOracleTableDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzurePostgreSqlDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new AmazonRdsForOracleSource(),new AzurePostgreSqlSink())
                    {
                        Source = new AmazonRdsForOracleSource()
                        {
                            OracleReaderQuery = "select * from faketable"
                        },
                        Sink = new AzurePostgreSqlSink()
                        {
                            PreCopyScript = "fake script"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Oracle_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultOracleTableDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new OracleSource(),new DataFactoryBlobSink())
                    {
                        Source = new OracleSource()
                        {
                            PartitionOption = "DynamicRange"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_NetezzaPartition_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultNetezzaDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new NetezzaSource(),new DataFactoryBlobSink())
                    {
                        Source = new NetezzaSource()
                        {
                            PartitionOption = DataFactoryElement<string>.FromExpression("\"pipeline().parameters.parallelOption\"")
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                },
                Parameters =
                {
                    new KeyValuePair<string, EntityParameterSpecification>("parallelOption",new EntityParameterSpecification(EntityParameterType.String))
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_OData_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultODataResourceDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new ODataSource(),new DataFactoryBlobSink())
                    {
                        Source = new ODataSource()
                        {
                            Query = "$top=1",
                            HttpRequestTimeout = "00:05:00"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Sybase_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSybaseTableDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SybaseSource(),new DataFactoryBlobSink())
                    {
                        Source = new SybaseSource()
                        {
                            Query = "select * from faketable",
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_MySql_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultMySqlTableDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new MySqlSource(),new DataFactoryBlobSink())
                    {
                        Source = new MySqlSource()
                        {
                            Query = "select * from faketable",
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DB2_AzureMysql()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDb2Dataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureMySqlDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new Db2Source(),new AzureMySqlSink())
                    {
                        Source = new Db2Source()
                        {
                            Query = "select * from faketable",
                        },
                        Sink = new AzureMySqlSink()
                        {
                            PreCopyScript = "fake script"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Odbc_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultOdbcTableDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new OdbcSource(),new DataFactoryBlobSink())
                    {
                        Source = new OdbcSource()
                        {
                            Query = "select * from faketable",
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AmazonRedshift_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAmazonRedshiftTableDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new AmazonRedshiftSource(),new DataFactoryBlobSink())
                    {
                        Source = new AmazonRedshiftSource()
                        {
                            Query = "select * from faketable",
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AzureDataExplorer_AzureDataExplorer()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureDataExplorerTableDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureDataExplorerTableDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new AzureDataExplorerSource("CustomLogEvent | top 10 by TIMESTAMP | project TIMESTAMP, Tenant, EventId, ActivityId"),new AzureDataExplorerSink())
                    {
                        Source = new AzureDataExplorerSource("CustomLogEvent | top 10 by TIMESTAMP | project TIMESTAMP, Tenant, EventId, ActivityId")
                        {
                            NoTruncation = BinaryData.FromString("false"),
                            QueryTimeout = "00:00:15"
                        },
                        Sink = new AzureDataExplorerSink()
                        {
                            IngestionMappingName = "MappingName",
                            IngestionMappingAsJson = "Mapping",
                            FlushImmediately  = true,
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AzureDataExplorer()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new AzureDataExplorerCommandActivity(taskName,"TestTable1 | take 10")
                    {
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_AzureDataExplorer_TimeOut()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new AzureDataExplorerCommandActivity(taskName,"TestTable1 | take 10")
                    {
                        CommandTimeout = "00:10:00"
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SapBw_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSapBWDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SapBWSource(),new DataFactoryBlobSink())
                    {
                        Source = new SapBWSource()
                        {
                            Query = "fakeQuery"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 100000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_ExecuteDataFlow()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string dataFlowName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");
            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime-");

            await CreateDefaultSapBWDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            DataFactoryDataFlowData mappingDataFlow = new DataFactoryDataFlowData(new DataFactoryMappingDataFlowProperties()
            {
                Sources =
                {
                    new DataFlowSource(datasetSourceName)
                },
                Sinks =
                {
                    new DataFlowSink(datasetSinkName)
                }
            });
            await dataFactory.GetDataFactoryDataFlows().CreateOrUpdateAsync(WaitUntil.Completed, dataFlowName, mappingDataFlow);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new ExecuteDataFlowActivity(taskName,new DataFlowReference(DataFlowReferenceType.DataFlowReference,dataFlowName))
                    {
                        Staging = new DataFlowStagingInfo()
                        {
                            FolderPath = "adfjobs/staging",
                            LinkedService = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSinkName)
                        },
                        Compute = new ExecuteDataFlowActivityComputeType()
                        {
                            ComputeType = "MemoryOptimized",
                            CoreCount = 8
                        },
                        IntegrationRuntime = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_ExecuteDataFlow_Compute()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string dataFlowName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");
            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime-");

            await CreateDefaultSapBWDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            DataFactoryDataFlowData mappingDataFlow = new DataFactoryDataFlowData(new DataFactoryMappingDataFlowProperties()
            {
                Sources =
                {
                    new DataFlowSource(datasetSourceName)
                },
                Sinks =
                {
                    new DataFlowSink(datasetSinkName)
                }
            });
            await dataFactory.GetDataFactoryDataFlows().CreateOrUpdateAsync(WaitUntil.Completed, dataFlowName, mappingDataFlow);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new ExecuteDataFlowActivity(taskName,new DataFlowReference(DataFlowReferenceType.DataFlowReference,dataFlowName))
                    {
                        Staging = new DataFlowStagingInfo()
                        {
                            FolderPath = "adfjobs/staging",
                            LinkedService = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSinkName)
                        },
                        Compute = new ExecuteDataFlowActivityComputeType()
                        {
                            ComputeType = DataFactoryElement<string>.FromExpression("@parameters(\"MemoryOptimized\")"),
                            CoreCount = DataFactoryElement<int>.FromExpression("@parameters(\"8\")")
                        },
                        IntegrationRuntime = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_GoogleCloud()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForGoogleCloud(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForGoogleCloud(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new GoogleCloudStorageReadSettings()
                            {
                                Recursive = true,
                                Prefix = "fakePrefix",
                                WildcardFileName = "*.csv",
                                WildcardFolderPath = "A*",
                                ModifiedDatetimeStart = "2019-07-02T00:00:00.000Z",
                                ModifiedDatetimeEnd = "2019-07-03T00:00:00.000Z"
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("additionalNullValues",BinaryData.FromString("[ \"\\\\N\", \"NULL\" ]"))
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new StoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true,
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_AmazonS3Compatible()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForAmazonS3Compatible(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new AmazonS3CompatibleReadSettings()
                            {
                                Recursive = true,
                                Prefix = "fakePrefix",
                                WildcardFileName = "*.csv",
                                WildcardFolderPath = "A*",
                                ModifiedDatetimeStart = "2019-07-02T00:00:00.000Z",
                                ModifiedDatetimeEnd = "2019-07-03T00:00:00.000Z",
                                DeleteFilesAfterCompletion = true,
                                FileListPath = "fileListPath",
                                PartitionRootPath = "PartitionRootPath"
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("additionalNullValues",BinaryData.FromString("[ \"\\\\N\", \"NULL\" ]"))
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true,
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_OracleCloud()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForOracleCloud(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new OracleCloudStorageReadSettings()
                            {
                                Recursive = true,
                                Prefix = "fakePrefix",
                                WildcardFileName = "*.csv",
                                WildcardFolderPath = "A*",
                                ModifiedDatetimeStart = "2019-07-02T00:00:00.000Z",
                                ModifiedDatetimeEnd = "2019-07-03T00:00:00.000Z",
                                DeleteFilesAfterCompletion = true,
                                FileListPath = "fileListPath",
                                PartitionRootPath = "PartitionRootPath"
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("additionalNullValues",BinaryData.FromString("[ \"\\\\N\", \"NULL\" ]"))
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true,
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_AzureFile()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForAzureFile(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new AzureFileStorageReadSettings()
                            {
                                Recursive = true,
                                WildcardFileName = "*.csv",
                                WildcardFolderPath = "A*",
                                ModifiedDatetimeStart = "2019-07-02T00:00:00.000Z",
                                ModifiedDatetimeEnd = "2019-07-03T00:00:00.000Z",
                                EnablePartitionDiscovery = true
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                SkipLineCount = 10,
                                AdditionalProperties =
                                {
                                    new KeyValuePair<string, BinaryData>("additionalNullValues",BinaryData.FromString("[ \"\\\\N\", \"NULL\" ]"))
                                }
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true,
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_ExecuteSSISPacakge()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime-");

            await CreateDefaultAzureSSISIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new ExecuteSsisPackageActivity(taskName,new SsisPackageLocation(),new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName))
                    {
                        PackageLocation =
                        {
                            PackagePassword = new DataFactorySecretString("fakePassword"),
                            PackageName = "funcInlinePackage.dtsx",
                            PackageContent = "VER001_H4sIAAAAAAAAA+19+3faSLLwz5Nz8j9o2T1fnBkD4mWDY/velhAYx+DwNp7M2SMkAYqFRCQBxnPyv39V3a0XBgfPZPbeu2eVGKF+VFdXVVdVV3eL8/96nFvCynA907EvUrmMmPqvy7dvzqu97pnyaGhLXx1bhgCFbO8MEi9S6/U6Mzc11/GciZ/RnHm2+9XqGi7AyFZ9L/X2jSBgbdeYNPSL1CdVe1CnRpgsu4bqQ1tV1TcuUqfZXD6bF3MVIXeWL52Jp8Kn5rOiLXUORZthmztBOq7szBdL33BZcbmVlu8a5DYt5sXKdlFWpEY6Cun2Pj+a2sywwzLw16hepH6vntRySv7kNK0UTmrpoqKI6UpJzqcLVVnMk1OJFE+lb2GtiFi9zeJFdGuOqxmsOHSuY3hLy79I5cP8G9Xzm45uTkxD/+Q6+lLzByF/ihkxUxDFfCYnxmo4mmoZiHROLBTC5NvxF0PzWV89zTUXfk/1HsJsjhdDtxQlu44P1aC5G2NlWHHMOBrS0rSAs5Xt9Hqf0k0isnwq5srpkkzK6WJOqaQrInwrF2q1k3ytIBWLpW+pS6x8zhtcGK6/wQQGj6HM8QNyzdWAAqnL8nk2XikCIzu2zfBuqjbUc71LBnF3LsvbJaqZ55B+zYuiODEtIyfOM7rvPf6WitdPCmqtcaMksgOBUnKV0kmRFNLVcoWki1KtmCYkd5quSCeiVCY1uVw9/ZaoGefgNgqpy6DkeVQURpUapn+v6yH6YYGu75r2FAbP2ee+B/3mQ+Oz5yxBZj+7xsLxPgMC9O8ZQkI2Qim7EyeW/AyhH8gohrD31fKoRspndGh9rHpGZm3aurP2MrbhZ+YbfZxhRV/i5O2NUpV2svKUFCUlLxfTSqlYSANPS2kiFyvpU+UkB6IvlnK18n5WvhrJH87rjuG7G9lZ2qB5cqmXCjVsUKkr1QpUxMuCgzgJXSotFwf18gPKmQA0ZaU/NGzTN1VLkKGs5UwvkAgfYLCvTN1wL7rtm5Z808jlMrkPZOk7Qs9Vbc9CU1JToZ0Pqcs4jueKrbmbhW/oiFc8RxCY2pv5/uIsm0Wbti5kHHcKxkjMZcViFiyeYWt/Vyxjbth+Klm5q6LKLjodpXJnfXxolC+2CjQGFymptXLFu4kvj3/J966Ld0PndNltX1ykmDU9oPFkb6L+IHsNf+boyWxBINbUcU1/Nj8AuGp4+dJJWhtr8YHLG5LNxcxwtyQskTdQraVxubOPEym7kitfSk1Xur03LftkXfC+jj1xKavzT73b9qBwo6ttvbq47hZ+KV4PT2a3zVFpUqpnPyqnRqX/tVfqrArF8tRvTPoNp3lT14ePhW5Tcg172ZmYJH9Tu88NvY3emZeGLanouiNVe1w11/bameZAGopLazX5OD51xrfrx449uX/UJ7OuvDaMW8mcqno++2nUWY3Eq/NsvDdbRMjuocJ5NiFX8TH4on77Q2pxT54XGb6B6prodyTsXZC4X7nt1GuyUqmJhUoxfZKTS+liTa6lSVGupjGtqojF09NKIanXGrZmLXWjYVeN8XJaXc4XF6mT03IlUQhb9BYqKIUUjve9ijHAekvfBcmUSxG1KeJARTaUC6lLkRErUTxB4iAnRtkk9bb83gRJo+T9Julzl/pZQuho7aZ95Bx2k35Z2C2DOWzU6dsHM2CalD8lBTlfSJ8Wq1K6WC3l0hIpVcEY5ZRiXszn87Vckmn7ndU9+EQeZjq3l3v78OzNoPP6lYnGRtzDWi/uPOy3cawJsAeYGR+THIPeP8VcrmLkT8V8MT8p5iZG+XQ8MYrlkjEpF9TxpJxQ1INujzTVL44bOdil5wVMO1ZATOTfqPZ0CXwHl6k7U93Flv3hiDZ8Y57ULQejm9G8BQDZMi+gf2CCgAa336uVU5fnf/tVrpIe+fX8+XROMMLCS3+SLrP5HcdM6DmO5YWdK2L5qjFRYUrSU92p4YOZou7+ttHywFrPVW9rJqjjjAEd8+zcG2M1NDoF7usHLnvddZaLYGBxPFAM60tT9y5/L4hVMXdSq6QLp4UiTLsKhTQpn+TSJeUU/OaKkivXCt8+/F4joI4UWUwXxFwtnctVC2lwqKW0KMpisXZaUWqS/O08+ww+bxcU6sScLl06KAV40k022IR3/zhKZL5/J1xcCO/eCalLquLALMSzw46AFzKBqco2rCA9BobYG/lTH3DjWTFaxCZ7l2U61TsVC7QX8Rxevkt5ECTmM6D+kklJGmP/L38vlnPaKchbOn8yrqSLpUo5PVbBcy0W8lo5P4H2iuOIbrQOB3O79GF+jZS8vDHHrupuzrOxNF6KLBagvMypbbg1xwKn7ZLz3TS88+zzXF6t4zh+aCUuDxgY59lklaB5zzPmY2uDGYeBSdTgUJjs11xIWjvuQ0DPVTFTOs/uyeRVazAjIhb0EN3Gy1Iuf55NJgUdNjzHWhlB6x1jYoB7oxmNKWgbY6sN4oN/PV76Bm+saXowJ9Zml767NIASPwTW7r4D93CSd/ms30EGM6XPB3dyvB8yxOjwwgESGF187m7mY1BRvKeJpHgxKoKTpWXxMnGRvAU7OjefIB/nCCC0wXNCsD+p/uwy83ls2p8phM+BdNMMXlSx0Vj17Tn1wnRacAq6NQC9Nz/EdWLaBnTe81Xb9y6ritSvf+h1iKwg4snMoE3XddwOTL1d/xJswXzhQzuxNF5sqLo2tESDNpfF82zi+ccxqWNYBszh9rGJ02EXn0KyM1Z+lwu8pX8JH/4HOYDOQcIkhsNX4L41OAobD0pF87T9ZTLoMR1UcMgn4Rhf8w6qcTe3Xi4XcyODkHCmyTnQ6x4LgZ9Bo5jw71iQwdFYusaFbSx9V7WOhU/LsWVqH41Nz3kw7ItypVws6ZpeFsuiplVyr28/cmh/ZPvn2STbnnMxZukiBCNT+DnWEwxcgybdWSzQ6Q174oAvGPOeu8sxVXKyo4PAB0/BbIfDDCV4PjZ03dDRUmBwZmdbQaaXcY1EfLFuQC8wbn4JRe7QnGGjYep5NioQ1sEoNiSzoXsZgQ6IAp05zyYLBbhvI3sInXY2EOsCRougpcse1T3BUzTjMBaGrYN57i/AlCcJgWohnruHxC3H3o1a1/B9UANexuNfdlI2KNWFD8tAGr+GvmEbB5AXET2EpLtg/lGKPqPBgUR9hh8bzk3VtP/oaHg2dP+WTgfwBX9mCHTiIrhLnJSCey6ogvx3YcH84Uw6zcf7HDW/wN3ki9Q/jppdOlGSTBsN1fvPkTJiU8OMzyZUoQrhdZVH37BRLYXmZmB6S9Xq+kvddKIe1ix15bgRfwS+3HLQfCk+Lw0ajoG6crzEHJ5O4Wkqj2tglKFATsolQtKnCqmli5J8kq5UimK6dFopVWqkRGTx9FtKAL0HCpR6DCy2sPRg8hjNk4FrQs+YLzBo6yGlLlI45QT7jCoOGAUmW78BK5xIH4LDCWJTNV1MbmiO3ZgDuBvT8zEhHr88R7SF573hY8jQY8Gof3jqxOCstSGZgwaxfASw4PMirB2kky0zcuVjzTZQnnHhDsZzt9H9Z7eXK4oMSiwrHi/cDRDmDFvcDkX5mXCEMBKCFKZe/vbbZfiAkv+qCMV+6/CjAxIuzOai8cigh0NIQLsjsMktz2Of3KILMPmNJ/dgGC9ccw5zVGHqgEsoOBMY2yYd0DDbEeCb7wiqZTlrGN+eCfJoCHfNmyCfgfFnrOgc+GdthNkSZFPAWBY6lxnaypRJFeIAcissVMDHnrLmDA5mpbqms/QEXP8QfBgUnqC6hqCjwfBnoIimM1oaxwv4nkAsH5wGzVLB9nscBnx3NBPFV1ibPisfwcvEO688qtids3haJpMRVN3BFZcsdnMGnQDSCf9PYIEcLMAlDLjLcgWbigA8z825ge2kLn3j0c+GMZ80M49hjcs9IFbB4i2NUXy3uEsfUpfc7YwED6UgeOrQQsfCLm/2GLtzQENr1/S/29CQFnpdQ5QzrA0cRzkYECsajKYyiBK1ESwH5MSj62bnWZZ7roH6Qz0QFFMFnnKeDbLOs3ps4SDWkOxYjgsOqk+1bjAbcNU1NJChmWEfeGrqUrLQdu8BKJn+XF0AxID9Fyk1Uu7Zx3QU+8PlSocGbDMwc4NRl8F1vpNiwuywPv7KcihQpglApD3DNVULJoO6kGkpPSEMMggM6m8BhQItuAdl1N77SIB5zyjwyr5tfEN1XfXV3aNcBs2xAElBMwAPqoDQBAqOap1AZxxCANpgIBG9/cKyg1zxK1SWrkE1kmpvBHsJ3reLyKRCsU4JLog8U4dARR+8r0BnMhBIfYYgaEDT3dJHqjZjugqgBPURXax1TNUmrcoUKpYBhe3EC3JtDGwSwB8LWJahChPKuYAo+JA60+mMgFR7Moy95YL6ahwKajCGqkZ1LbUf+9Ww6mozEzfEwDQxw2HIXDVT8KDG30WN0JGLtIyJNPbQA+c9rrsZoKArUNrPbBuwMBMgLj2ojM5oDCyTDI9R0Dcsy4tBfq4qhRlQFgikg98NnfZ8WppLthAIkbYEatpo7WwnIJnBHAtq82rUIZ6aK8OOEERAjKTzJcAd0/4IqgasQTtvbRK2qOWA3KeF1+oSarOhoecWGlOfa2ygtWUF9hnkDLpvAE9paWZhBA3MOYODCVT8+SBkjXiCBXQCUo8NcBQSDAr6fvbqfgQ+AZJLEM4oq1m5GPVCJlOBSY7cs0CJdXkx2naG7ZOCjnsZibXHbmH6NhQqNjPgY6CmaFuc2IGP9sc77Tnq4od3ubME7Tk39ne9i63ix5/u9h/h85Z9eF2/TZuqr5hZ2EZ96THLwYmBs1rwIW3cLWhYmYTe+jPMDua4j55+xt1DUwe3DDz0cBmQfzmDMnv3moCjyVz2oPDcQzMAbr9rc8BeRMg0GK0zKJdmpcLwMmJhsF04gX9IEWHFzhoeRjy7BswDMa4cCwlgRYAJVuoxFgyIsmaOqYHGUh9vNdB60KelPXaWMPfTt1Zxn2MAMqHGkUwC3tlmrIBnfF1i4HKHRd7RFhWfwKeh1ak3ga6LHWAuPt/Cg2b/xcZoU2qwGMQbY5Pg523tgL6rOp0k/PHq4TzjABCsd/tozXI5Ib/HTZXHWP8YN7c7AaNZ9f4EEQ5lwQ8kwP8yUeYj+xadB9x4mNtFu50NcL/39U3k/+oBdFCfXjWmtiEWfsgw24Za/EsFL5ph/B+Tvh8pGuDbIyW+Lk2YIfwocvNa1MbFwoq7QT0HwvtHbTRLeDEsxMHwGMeuGFE0e90Ol+yPFiWg0tDRK6C4CbniQP5ERClYO8wfunQ4Pj1VS1rpJFcpFA2xXHkV9kFk6nDsXw5T/YXYwxOGbn9UmHnnqtOBweZsNv1Dr7dvslnhXF36TjqYR+JuKEjEi06Z0ZkW1qoXTjRhsrgBF913HCuDRcPi8ky1pwaNUbBINK5rzcHL11TQAOD900CGhrOCmboycZ5t62wSC/MECxc1zEkIDSeptG2A5Bph4xmGcnYHzj+aNG/f/Bo4TmfC1HLGqnV2FoTXTHVqA8am5mVwRY6AJt14JkzPlguMgXlN+FOnRrgX6Sh+Xspw6fQbFGvqWEjJJFfO5c7IyjH1vq2ploXHoswVdAxBQ5Gu5iyoU46RK3hmG5UO214ZSV4mlDyo/E++CfLo/dkfgJISfmESm6LLve9/Q2rZwbKT8DqIwu/xKTj7NPFQBtAUpo8qkAOXHeipCRb1CjoiPONLYkNPJrZUF1SRYEIYNBg1h9evW6CCmThfWnVxu4WJSilICNfbIiYjIQJ4C8ZCwfMBAS3CWWeEb9AtOECsC8E21mH20fsPu5BbUOX1DBZnYrxDeAF/t5Pwcg3QiPY2Ah+SBb9Fj/wr3L79KeWXXNI+UNX9HQY9Bi6vDGtxJggN22dbRGkw06Hqge0gF3zVe4Dx/zONPsS2aLPVL0/YOEussWCjTliZrr+ErA0Lhy2C1S0W/FVtVEYY2QMfwgQjgGELQPlnGnfFoF8kUzTEYNpcVdnoFmB4DUDgmaIphxvIDS3iOpYwwVCbQGHSD+VxwYMXggMfrsB67gnrmanNBNCVhpBCMqRApoyJ+ciX7Q22DEaX/ryFoZkTEI21uqEaGDQuBb4Tk4mhom30og6Ako1RMyP8DGr974atM1RwdMMz50i4vOy9fcMCNmzEfEg+0o1aYdqunUtV3wtG2XbdhHXfzmTb7SHhwzaSr1JBb9/wMZJFi+It57iaehklRWIbRGbBeXQ3wsIB7cQ1EY+mMtplBKHq0LCyRk0hzeJrAIGK8I6jBoCHoNfQfw8WbynQTAyrbITWT7/uoyEKuxfbB5bBpfnoUUGsPyHSoaICNfUTVylbmjXq89lenj1rDw8RdHosgR1roAE71LXQUEwTbQ3qPuXqThFdhccm+KozkBHjnzAacT2bNhXBxcFPZR7ygppCUrCPwR9xwcUwbA9EP4qrh8Vn4OOMDQPA49YsHEMxTfWzYJh0bGIVjJkHqzdUP/AAvarf2tYmOvCx4HshkdG76yVaCIBQR3cXlMmzgXocrUEgwuuZQZGE9lAKQfG5iRaoP2UbBltIoi54oEsDMoAMAyWBBInUY8FDLZQgpwYeG08yA1vmTBLtsa0cAtvLwZZxlgsdjeJugmGBBID95EC/gRM+UPl4UpIta6AkKbrpO7hGgookk4AaikooVs9lxaE7J+jYhiJgeI2FlxE+RXJIlxMtqm5RG6Ud6EmymcQD37OATOTKS5i4zjwmr2eJ8gK+PqBn0qZhhNJvF8JRkPpewIEYUuVXvhYMzktQOvVbhh4P+3AQTigLXIj2Y5RsEc+5nZ3NN+xkbHiwjTcLyKbQr2ExicOQ2CLMgu3Miri0hQ9q4TFu7G/oSBp4fEaVf/DdXWdnvOBuqhyMET9T9KcwYjC+g9GBCHm4bOmbK+OvQq1u+N2gDYpmwj8FwOgoxPR7whqHqUmtXzPdvWrfWIE59MLu7VDzWxqQemyg2Y2wKgx6y6F74cFrdhegpLzDxuWE4QXwDNz6zgDuGAMKbSgD3TDoHvmjXBlmcUA86IAnUCp5OK+TVL7ujw/wJ74/jMcRHqYd6bMDsGlExY8KO1HiKQgezR1VLYYe4HcM4kWbN8gUTNT7V2ELnic9DHAIovzcwFGuuBPLlsPohppVM0Dy2M4A014s/T20RDF8lRC+4Hpo4VFkYc7PIu/1OroO6GW24w1osasmn1HQ/Q07XW1omNlD31mAP5boVopvC2WLmdEZaSE4JI37c6EDyHQMHGxSlFK6AS6GdaDY8zVXWyDVWzrDed6LLW7yFV5XXccwuqBMjhLQJqlosKsS6BGi0ehvlH1EHUk02Sp93uKnAB5nDPh8A8i1lF6ivaNEmfcJdLagZbN9zwjmaQEE3OOD7KNeEW4ROmYLyC47lrNV/LlA7+srP9YT62sCtWRPv8MVAffJ7+DIH2PIJ5cGMJ7MxR9hCd/khWE93NaMHGBJ/8OkT/TqVcR/QW3AvOWnHfNCOuwhmZqhOX1FBd1URIN26H8/H+EwT8ez6JG/mogDJMFKBgxfgwdqQjvvR40d041H0XYkkJRgRsbes4QeHLi8GKEA13GpUdUKKmECCgE3eG11w8EACFOKxwINXAq13FahxCQ0mDZisFLAeeLRe0zdijYh6Nvq7ZlAYCKB05CI08mCbCqf6VqGsTgqiCLV6z/99NNWp7jHwjx9loahVto7WuHbLlWfKA5KEaa4TNdv9e8FFhv2co6+Fb6dhW1AtMGM4VZ2wZs5LswibT0eBvIwUpuczvNdbT7zr2dGshWXdTAZR0gW2YHWjqA8BsRDM/ACB4N02rMEhaK8LW5yQgMXvhPFyVR7XXzzAgMYMOg4Ca3GJPHV0Hi9WHjyw77B+9OfDlny7JeClbmTG+XgcwBQPp07SaHHZeuq5eDpjw14O/RkgHYWvKyA7SLSvvMSAuQ+9/fnFr5cTsyK5ewcBmO0D2n8x15kILiM9skXJnjxQ/esb2ydDOqGLypLHA7EDFy8OPyUeqJGDEpwsOZy7tHjR6xkmBorWTW9haW+4mD8dqUYrEA89MvfxZMTUhXFXFrMESVdlArFdKVQqaWLJ4UTSRQrOUXMf2PAolpsFXE3eWgDz45TxurHDoMd/v6M6LQlQqq97hjhgZWfH/Q7sOL2Ic9XI0tP5LwWy0N7mFyfCA/AbrPpPBsO1B+2GLxNmAMXRxLh8I4xsULXK5mzZwnrAypJvnLLVrEsITZ5FNSxs/RxShCsf1Ifh7kt6OfEN5OzSBk2SsGhe4JrIGG8O8PXhbEwBt3CPSN8igf+yhzfBbmh0GIzXgpu+1RQDCe++Bxbow2I2TN9yzg66F05uGC3A0Ls7URHqX2FEmuNLxWbL1R7s78Af/fJn0JYdhYb15zOAEr4VfhvQcA3j+6rA66+DmrdfXgBd7aJghfgEhMcSYtHJ+gx0pi8gLDgDnwv2m4eSMkEvUHG+7PE9gGBvqcogB5LxrcThY1G6dQaCC16miNK7RgrM6hPU0fOks7B2QrZBhcFI/+ZusYbXoKvi/LYNANDQ9LxljyGwXjDZ2hY+N3P7wSMpsyctc120p9t7R4I6Ml7cYQmNPMzEPWHbyoJNfOBmiTptrwDvN5Fbss703PS5XKpks69o55K0AzVn3yj9NI1zyJ7ILPjFfzdKRepI75E/T56RxJmhMc9+TPvUVQ61MKJCiECNPs8G8fnLzgH+p8dOv/ZofMv3aETiR5u0QmeeLAPt+rs2CDnLKPdOFHhbY3+70edwDaFVKnTLgZHZnh2w46oM3H+vanixajyMk2AEiFV3p8NAMW/YA/Xnm0VgkAwlOjgsbk0hs51DIKwl7bQgMkxX8NxaOR7uYCvGj9BxOKNUMLwtT3bJFga14w0/oKqMamMUD/SlWOOBu4UDl/GQq19EGEFSAzIylS5ShUs84EexwPPGd2HxCJ3JkKAraI7uJ1n7qxwuZlxGpDXTbY4L9ANrkwN8/gnzL857BBSeKQyC90XHOqVHjPA7E0eFNSgG77Cg9Xc3s8WF272uijDbTk2LuNSWX+2iS3cg8coEMrZ7u1zW9vdtjfTJTVWpKdC3sPz7p1vL8LdK98hXJ62E/ZLJPqrx398q2BI6ZBMR+/jVP62C/kXQpfoBmMEme1a0lQNt7FtEz7ctEGXpuiI2NqBtG947SLd1lE9tvtCwlPVuLocEeyg4l3gtZEh+grx03dS6rVitv182I5JcyIcHcUkFF8QZy8t6/37XaUpoEMRgtwF3/t5aJ2DZog7TQMIJGpaZ3IUJr3PBJOSxJpI7Er0m+K7o+C350l8m+nugb1V5/WSfQtzFZdG46lss+kGRiQMVX/nBfOPfoOP+2j7FJ2iWtY2vND2oMFZLrxwXoerONw+CLvM1P/ZQbJfZwY0e9V24v2Kdod8ePtAJWCAuK2298TslJvvx/nZEfE/835i3bJSl73B1zYhTQKXgh/ZbJmQmykJrjY5/Hr7Bj9Z3eJkOS0Sn9itxngq9ZribFCfLbSNtNbmFVub1/xGvTUbz0srXZbM+6600YfFqQp/HaXSa9Rzq7dv7uv9ZbUtfrwOW5DaHUCoR5QqqZUfb2pi1PgtIQ2T3EAmto4fjSDLNdcMt2m8R0qAKnxKEZx69FUmQT67mmTU6NPCAE0KoTDCUfS2CFJbe5D4KSx4NVXIjovRjbW83lXgVReD1ojwDy8ZE5TpVmJJvL+bUUL6rHVaoDplUDhuiRoU16VmtzYjrMB7xeg6ir4mLon+vX1zY19b43rlC+FCx+lNUa1Nn9dDUO0d6VClDdCCB9YrgNInIsJqtT+SOD8+tl3ILu6CE1w7ehq/asXpkgA75Smi9JGY0w7ea/NyF+8fZ0X5o4Rdcr5eTRvO2zc1RMj8upxQ8rT9K7sB+EhrkXa84dQAjjwvD7G29qjB7SvtrnRVRLyVj7PFL1Q2ZccA3BxKI5a6ZqmAw4i2bZaeMFNySJWWgVptq/WxjS1zXmAGuRqJN1/I8u2b5hN5avYeaI7Uljy8f0G85NYvULaILchAS3ju6VfXi/Fcf+J0gMEoUWlp5AY9ctW+pnSjrTREfdDt41dZkdvICwUhyMBvMyIkSmbt7kqFLrSREtUT0msy3rfZyKJSWKO4UbZSPCkv6yEE3i+aH2kvltoMywM03v/mtBlIQ53ctqXsulknV02Z3qtEOiXNT/Cs0PyaKC0wvamx+8cpvQO0miPTFNJmd0lk96s2K9koS19J4yMMH7nYhvvHMoF7ndSV6nCK5ZvYUp20psrbNzSlWa5erdt1cvNQfZg2b8ltk1wRuCttid6bHpm0odynKWG4lom1BsjEqVLIVw5BOIjbiH4jn4oK4MKYFYzENtJDgX/ShqwVIAB7pjnySJlOOzX6jKTvIN28dleWag+YcgXUg9LVj0jAT20s5iB6c5KDh7Y8QebBM9BtDRwbLZFNA0c+kepNuEtZwA2+9bk6mk0lkC8Q3LbkMBUt1+utchV4LUFbbKw3mqMCpbNCDF7vYf3lhuQ1ylP5gdfsyQ2NjJHbHz1W87rZeFhLj1jT27Ca1vTLRLqCETaVT7ZalAFas8FrKqNSu1Xm8iXBsyy3qxOkl0LvI1KndwfUCdyhjSa/3/L72zdt/q3L731+H/L7iN9VDnHK719pep8s+fO6Xa0Bbo8e0dpVWQIabNpVV4JeabyEye8i0JHIoPfa1RNJXpMHTH+C3vN8qhQVB3CTUT0rZcBeeiI3Gpr5G5BYvPfI9RTvY55OlQHcXXL7gPcnfj9ld6mKdMMS0g25RQhSj+cAM0ZSey19wZa6vKVRG8QenkdrycU7SJVEByvKG4yAt28oCz5qZIYSe9tUzCkiTkvQDkhUYkd4h2cNlYQSmvNWeXyaLwcKRmKafNsYg4OQj77GL0kCGZCDgZK4wAzScRpLoqNmTe1ZOzKx/Vxn0qwqj7fD/qb1RDat6vW8Va3N73vTwmh+b7Wq09z9cFQE3ZuvmfdfpuSTklvdXw28+16R6POapw8Hk7u15Gv51kqbPy5GU6mvXl1bo2Gb3NcH89HdwNMVa6kVOuA3tSxSu869fTO2O4vxcNA37iSrW68t7+uPFlF0S691Slp9UAdvyw/TaVqfdOa1xfhqsLlvS/b9XWfSLgBkeAaPC/gVT4Hnzf1da6XfXX+577dy46tOTpv3ycBq9duD634/39qod5LYy19/vR+2xN6w8nA/fJRHdy2YjxClttbq0JN8TVSHlWU/PxD1urW8L7RoCaIMHtS7zkp7uN6MC/rTaHjt3Q9a4uiuA3mt1fhOWozrg00nPwCbdX93PdPrg4f2XUfU5pap01Ida2QP7Pv8YNObV5YDgKo9tFZAL0m/6mzU4XVOxx7XB6Y+1G3aQr8mvn2DVg1qitDD2n3dEseFaxloVdCAO+Ot2u271tP9MGeOr6w+4EshxOqDvGmFljUG2MagsxkNO/C9tlHFRKn+6O4aqV1H3/f+Tgce+ztbAZ5eWdVxvjRXhzpQm9Eu2evak5Yf+KP5Ywl69jQqXC+0K5CDfCkJMV/xAbe65QFFMbcLvJkZdQZRS+InRX2QNuN8JzcqdJ7hB1xgdKiOC1IJ8LHVq2Spfq51DX9fIG8NMjjT8n4NZHQDUFfqsCTG+0ElJOwJYquBpBpJ6nZ1qKUOcxbPh+/gjwDHtsrl374ZDR9z8K1n3LXE+6G4hBnH5n5Ye4B2bVJrlWDkWONuKYR4Y91b4MUiZcDD0UhvaAHeladx/h4k5MZqPY5rIE82lDJLPU5l4GMLdFhuAc8rLV+Z63Kppw0feyCf+fu7xrJz1Xm6sWjP4c4oAfJGaeGR3SNmTfoF6wmk2795oHK/Gs8HSx01RH3gAe79uyfy2OxZVvOLBtCaX9qb+y/tx/t5v9jKX4OWaRdbw8H8ttqajeaj4s28441JSAnSGZZy48RYzs1wWoZ9Agm56rRGQ2sZo9Ez+YvlXaE/B7ReGM/zuigh9x72jOYogc4YXI/n9ysoCXmDNamjhqp0E/jMazA+GuRm3oLRSO9fgG71yiYGX1GHNXsMPAI9ApSIeN23gV51y7+nuOfW6vDR0izKPdA/gyeEgeOUYRm2e9c8WHNzvb3sXwHf66gtoT1L2ySgLaGnT+PCYEPbDLUT6DyR8vJpm5cBJ4Fu+3hpwXgsSNCTzoLiG2pR+F4YfMGWgBJUk6PsQQtANzb+ri2NavImCeSNU14BLs304aNIrlr4TKW6D7jTNFYm1Ahv3xhoFq9qPQKTlrs12OSqAr4PKREY8c0pKeD0Au4iqTbIPb0rcJcstJ+ttWSS+ojctzEd7WmrDTmQAmb4CTxjApZujjngPbTJVYOM12DdAbI2hZlG/YGgVcLJWx8hQl8gP4flwJtAHXKF1lkqit0n5X5Usrujea2t6xN3tDilc8e20iDoCbb7+L2jtGnardQFF6FT6+CkDIpBIYLS2wbPtHO9UIYiTdHaoymZKreKrTT8wkIbzB7EYuOhYY46YLBk8nSt8Dl9mzkc61G3C/668iCCVyPNGm0yHTUgFRxsnNxdX9PJ3YOI/rYEd6zdVeicRVHAnYDa7QaUa0ngCiszcEbbzCGlXo1BPflaW65Z+mZ0J93COK0ZdZBzpv/RY1jphSY4jGF8AyarCszWXqtDCM7BmDs0hHsH9O/auLte3OdnYkMh00a1saZzSOUBPS7JWfYeBv2OfT0Df6QA9tS9qQX6tVjRv7SXrbZCBqSYKNOpW0/gI8yMfgnS+t2bhxL4vQNZitlJb9qSizkfMWmefjw9pfNj8HPho/4YaYDYyLuxQPLzFdA76IdAzgzG3uZGjnlX5no6mA82Wt5ajb+IdF7clItrKFPFMQDj2fo0LFlgp8Cir71GTcqBlQJtORJ9C+z8SgWv5NOwUWjlldzoqZ8HWjy16v31bfXhS6jNY3igpggsT4ArQMsPwHK0t0I1Urvd79A/2utG20tkXxfpcyNZ6VkEQ27fbJUgtQpY7mtlXH9kGr+eexrlK2Al++gh8laqWZg3TqMY14+4vhNd+Q+0fzW0NhvbGFHZGV5rM+439+dzaBj+IrUZfqpbAqNKVWxEGpJaE+wG3JU+avEe6AzSW0u3pEbniLdEGQG0Hg9+rtq9VZbHg3C+dZrPTuqY166uxpXy+FMUJGW6dweC6FvS6hLGRWD+ucE2VIx1gWWBNpdogcYc0jWHNMD4CFgk8I3AMq2xHrVA4JOvoUZw3RDFoHNChfTXUAJskUohaqQzlRZYE2zWNakX0QquKGReHj5B91J7iXNboA/YF4pFfcpiMjB3XpG6SMbUSsLckEhPYctyg3FGoVbQx9gM6BBs+wooOpVmWPM+Pom9YiG7eO87hNlRsJ8b7J1GWC+xj4GESH+xrYfrF0LKaDbrtG3EqYY1ASfADXBdYe/pBS3cTCndwAtorckjqTZJq02WiAOd11f7+EwvDcNTQEfK46s2gwiQRth7hd597Av29Mf0EvuIMa6dHs0DSsOYyuoU/wMnqHTYVM6IVCX1MnKgxKXIRkEA35LWaDJfCHirUbnSiIq8YpERGiFpThnutzTs6nDpSLTQRx+pgf1+wN6BXM1oW+uYXBF0LRjdelwq7tfYYkC3SHpgLMTlDEY2jJoJpVcbOYP+GvhbVQ0lfIMS3qTUgDvGDAECUKlA6g1KTxwLbUzJYQ5Quoi8hTZNTk8YVW3sBbVNKg0GKxgP2iDd7gl4gvUmjpFb7C3ghvL2gyQYcWPc3S3BGJWjEhx4rQ/kqo+jStwlyXRkPaIEN7FXSJ82QATJBdne0JamQAV4ZpptRKoYJQP3UkNOMc6ZKE0Gs867R8vhLSS15Q+8/gPt3wIaijgNfHrV9f823P4D7T/QXrjOs9H2iMSrVRO/Qh17u+oLP+4e/eI237i/64fGz/lPf5tTG99RE/v1p5fOUdKjB39Lp+meTlpK8PhB8vA3NOj7ldQNnluKn0vhx0/4q2TYD3B44SF0ev7LS1TwltoMD3McPR5v3gN4+nIl/CWvY2Ft6v6MvcVoZuABG/ZbaYhZY0JPkcxVm71Zju7wZFuIeGNYa64+0G2gpufDt+PYwRPL8A3B9DNCCLEXYc024Hs+34ZPX1blO4LlqLpgI+LY4njJDq4sXGNFf4tpBzESG/mDV87pwW840tzEKWLBNdL4nv7gVWb8/bme4NixqkAyd6JqBqcGEw96mDg8MFpOhT98RX8rxcZTA/SgDGs1+MmV2Lud+C+P0PdYqZMJfb0BO80WHk4If6qOv+SHSSNDKo0l0+xVszw7fNfsDaUMbniKJLvuqosZy4jGgawCB0x/Q18SzU+7aJabDjdJn+06wRx7p0j4ysjwIAnbyZX4cYcPwXb0i0OhUWQTP83TArDb2AtC13yC7ucKxeNiPnF+paGHVPm86zft8eo5ixtj4l+kCqcnx/lc4v3h59kYvUItsEXX8yxvgp7U4WLBDuns1QJYckuZ/H97Nw0twIsAAA==",
                            PackageLastModifiedDate = "2019-04-26T18:32:46.260Z UTC+08:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_SqlDW()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForABS(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultSqlDWDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new SqlDWSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new AzureBlobStorageReadSettings()
                            {
                                Recursive = true
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                            }
                        },
                        Sink = new SqlDWSink()
                        {
                            AllowCopyCommand = true,
                            CopyCommandSettings = new DWCopyCommandSettings()
                            {
                                DefaultValues =
                                {
                                    new DWCopyCommandDefaultValue(BinaryData.FromString("\"col_string\""),BinaryData.FromString("\"Cincinnati\"")),
                                    new DWCopyCommandDefaultValue(BinaryData.FromString("\"col_binary\""),BinaryData.FromString("\"0xAE\"")),
                                    new DWCopyCommandDefaultValue(BinaryData.FromString("\"col_datetime\""),BinaryData.FromString("\"December 5, 1985\"")),
                                    new DWCopyCommandDefaultValue(BinaryData.FromString("\"col_integer\""),BinaryData.FromString("\"1894\"")),
                                    new DWCopyCommandDefaultValue(BinaryData.FromString("\"col_decimal\""),BinaryData.FromString("\"12.345000000\"")),
                                    new DWCopyCommandDefaultValue(BinaryData.FromString("\"col_float\""),BinaryData.FromString("\"0.5E-2\"")),
                                    new DWCopyCommandDefaultValue(BinaryData.FromString("\"col_money\""),BinaryData.FromString("\"$542023.14\"")),
                                    new DWCopyCommandDefaultValue(BinaryData.FromString("\"col_uniqueidentifier1\""),BinaryData.FromString("\"6F9619FF-8B86-D011-B42D-00C04FC964FF\""))
                                }
                            },
                            AdditionalProperties =
                            {
                                new KeyValuePair<string, BinaryData>("MAXERRORS",BinaryData.FromString("\"10000\"")),
                                new KeyValuePair<string, BinaryData>("DATEFORMAT",BinaryData.FromString("\"ymd\"")),
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SapHana_DelimitedText()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSapHanaDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultDelimitedTextDatasetForADLS(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new DelimitedTextSink())
                    {
                        Source = new SapHanaSource()
                        {
                            Query = "",
                            PartitionOption = DataFactoryElement<string>.FromExpression("pipeline().parameters.parallelOption"),
                            PartitionSettings = new SapHanaPartitionSettings()
                            {
                                PartitionColumnName = "INTEGERTYPE"
                            }
                        },
                        Sink = new DelimitedTextSink()
                        {
                            StoreSettings = new AzureDataLakeStoreWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy"
                            },
                            FormatSettings = new DelimitedTextWriteSettings(".csv")
                            {
                                QuoteAllText = true
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                },
                Parameters =
                {
                    new KeyValuePair<string, EntityParameterSpecification>("parallelOption",new EntityParameterSpecification(EntityParameterType.String,BinaryData.FromString("\"fakeValue\"")))
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Binary_Binary()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultBinaryDatasetForFS(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultBinaryDatasetForSftp(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new BinarySource(),new BinarySink())
                    {
                        Source = new BinarySource()
                        {
                            StoreSettings = new FileServerReadSettings()
                            {
                                Recursive = true,
                                EnablePartitionDiscovery = true
                            }
                        },
                        Sink = new BinarySink()
                        {
                            StoreSettings = new SftpWriteSettings()
                            {
                                MaxConcurrentConnections = 3,
                                CopyBehavior = "PreserveHierarchy",
                                OperationTimeout = "01:00:00",
                                UseTempFileRename = true
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SharePointOnlineList_Blob()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSharePointOnlineListDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SharePointOnlineListSource(),new DataFactoryBlobSink())
                    {
                        Source = new SharePointOnlineListSource()
                        {
                            Query = "$top=1",
                            HttpRequestTimeout = "00:05:00"
                        },
                        Sink = new DataFactoryBlobSink()
                        {
                            WriteBatchSize = 1000000,
                            WriteBatchTimeout = "01:00:00"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "01:00:00"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_DelimitedText_SqlServer()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultDelimitedTextDatasetForABS(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultSqlServerDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new DelimitedTextSource(),new SqlServerSink())
                    {
                        Source = new DelimitedTextSource()
                        {
                            StoreSettings = new AzureBlobStorageReadSettings()
                            {
                                Recursive = true
                            },
                            FormatSettings = new DelimitedTextReadSettings()
                            {
                                /*
                                 "type": "DelimitedTextReadSettings",
                                 "rowDelimiter": "\n",
                                 "quoteChar": "\"",
                                 "escapeChar": "\""
                                 */
                            }
                        },
                        Sink = new SqlServerSink()
                        {
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Translator = BinaryData.FromString("{\"type\": \"TabularTranslator\",\"mappings\": [{\"source\": {\"ordinal\": 3},\"sink\": {\"name\": \"CustomerName\"}},{\"source\": {\"ordinal\": 2},\"sink\": {\"name\": \"CustomerAddress\"}},{\"source\": {\"ordinal\": 1},\"sink\": {\"name\": \"CustomerDate\"}}],\"typeConversion\": true,\"typeConversionSettings\": {\"allowDataTruncation\": false,\"dateTimeFormat\": \"MM/dd/yyyy HH:mm\"}}")
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_SQLMI_SQLMI()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultSqlMIDataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultSqlMIDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new SqlMISource(),new SqlMISink())
                    {
                        Source = new SqlMISource()
                        {
                            SqlReaderQuery = "select * from my_table",
                            PartitionOption = BinaryData.FromString("\"DynamicRange\""),
                            PartitionSettings = new SqlPartitionSettings()
                            {
                                PartitionColumnName = "column",
                                PartitionLowerBound = "100",
                                PartitionUpperBound = "1"
                            }
                        },
                        Sink = new SqlMISink()
                        {
                            SqlWriterTableType = "MarketingType",
                            SqlWriterUseTableLock = true,
                            WriteBehavior = BinaryData.FromString("\"Upsert\""),
                            UpsertSettings = new SqlUpsertSettings()
                            {
                                UseTempDB = true,
                                Keys = new List<string>(){
                                    "Key1",
                                    "Key2"
                                }
                            }
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        Translator = BinaryData.FromString("{\"translator\": {\"type\": \"TabularTranslator\",\"columnMappings\": \"PartitionKey:PartitionKey\"}}"),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 2,
                            Timeout = "00:00:05"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_ExecuteWarnglingDataflow_Sinks()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskPowerQueryName = "powerquery1";
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            string datasetSourceName = "DS_AzureSqlDatabase1";
            string datasetSinkName = "DS_AzureSqlDatabase2";
            string datasetBlobName = "DS_AzureBlobStorage1";

            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, datasetSourceName, datasetSourceName);
            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSourceName, datasetSinkName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetBlobName);
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryDataFlowData mapping = new DataFactoryDataFlowData(new DataFactoryWranglingDataFlowProperties()
            {
                Sources =
                {
                    new PowerQuerySource(datasetSourceName)
                    {
                        Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName),
                        Script = "source(allowSchemaDrift: true,\n\tvalidateSchema: false,\n\tisolationLevel: 'READ_UNCOMMITTED',\n\tformat: 'table') ~>  DS_AzureSqlDatabase1"
                    }
                },
                Script = "section Section1;\r\nshared DS_AzureSqlDatabase1 = let AdfDoc = Sql.Database(\"**********\", \"**********\", [CreateNavigationProperties = false]), InputTable = AdfDoc{[Schema=\"undefined\",Item=\"undefined\"]}[Data] in InputTable;\r\nshared UserQuery = let Source = #\"DS_AzureSqlDatabase1\" in Source;\r\n"
            });
            await dataFactory.GetDataFactoryDataFlows().CreateOrUpdateAsync(WaitUntil.Completed, taskPowerQueryName, mapping);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new ExecuteWranglingDataflowActivity("testPowerQuery",new DataFlowReference(DataFlowReferenceType.DataFlowReference,taskPowerQueryName))
                    {
                        Staging = new DataFlowStagingInfo()
                        {
                            FolderPath = "adfjobs/staging",
                            LinkedService = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSinkName)
                        },
                        IntegrationRuntime = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName),
                        Queries =
                        {
                            new PowerQuerySinkMapping("UserQuery", new List<PowerQuerySink>()
                            {
                                new PowerQuerySink("UserQueryDSAzureSqlDatabase2")
                                {
                                    Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName),
                                    Script = "sink(allowSchemaDrift: true,\n\tvalidateSchema: false,\n\tinput(\n\t\tSampleId as string,\n\t\tSampleDetail as string\n\t),\n\tdeletable:false,\n\tinsertable:true,\n\tupdateable:false,\n\tupsertable:false,\n\tformat: 'table',\n\tskipDuplicateMapInputs: true,\n\tskipDuplicateMapOutputs: true,\n\terrorHandlingOption: 'stopOnFirstError') ~> UserQueryDSAzureSqlDatabase2"
                                }
                            })
                        },
                        Sinks =
                        {
                            new KeyValuePair<string, PowerQuerySink>("sink1",new PowerQuerySink(datasetSinkName)
                            {
                                Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName),
                                Script = "sink() ~> sink1"
                            })
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_ExecuteWarnglingDataflow_Queries()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskPowerQueryName = "powerquery1";
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            string datasetSourceName = "DS_AzureSqlDatabase1";
            string datasetSinkName = "DS_AzureSqlDatabase2";
            string datasetBlobName = "DS_AzureBlobStorage1";

            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, datasetSourceName, datasetSourceName);
            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSourceName, datasetSinkName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetBlobName);
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryDataFlowData mapping = new DataFactoryDataFlowData(new DataFactoryWranglingDataFlowProperties()
            {
                Sources =
                {
                    new PowerQuerySource(datasetSourceName)
                    {
                        Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName),
                        Script = "source(allowSchemaDrift: true,\n\tvalidateSchema: false,\n\tisolationLevel: 'READ_UNCOMMITTED',\n\tformat: 'table') ~>  DS_AzureSqlDatabase1"
                    }
                },
                Script = "section Section1;\r\nshared DS_AzureSqlDatabase1 = let AdfDoc = Sql.Database(\"**********\", \"**********\", [CreateNavigationProperties = false]), InputTable = AdfDoc{[Schema=\"undefined\",Item=\"undefined\"]}[Data] in InputTable;\r\nshared UserQuery = let Source = #\"DS_AzureSqlDatabase1\" in Source;\r\n"
            });
            await dataFactory.GetDataFactoryDataFlows().CreateOrUpdateAsync(WaitUntil.Completed, taskPowerQueryName, mapping);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new ExecuteWranglingDataflowActivity("testPowerQuery",new DataFlowReference(DataFlowReferenceType.DataFlowReference,taskPowerQueryName))
                    {
                        Staging = new DataFlowStagingInfo()
                        {
                            FolderPath = "adfjobs/staging",
                            LinkedService = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSinkName)
                        },
                        IntegrationRuntime = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName),
                        Queries =
                        {
                            new PowerQuerySinkMapping("UserQuery", new List<PowerQuerySink>()
                            {
                                new PowerQuerySink("UserQueryDSAzureSqlDatabase2")
                                {
                                    Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName),
                                    Script = "sink(allowSchemaDrift: true,\n\tvalidateSchema: false,\n\tinput(\n\t\tSampleId as string,\n\t\tSampleDetail as string\n\t),\n\tdeletable:false,\n\tinsertable:true,\n\tupdateable:false,\n\tupsertable:false,\n\tformat: 'table',\n\tskipDuplicateMapInputs: true,\n\tskipDuplicateMapOutputs: true,\n\terrorHandlingOption: 'stopOnFirstError') ~> UserQueryDSAzureSqlDatabase2"
                                }
                            })
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Script()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new DataFactoryScriptActivity(taskName)
                    {
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        ScriptBlockExecutionTimeout = "12:00:00",
                        Scripts =
                        {
                            new ScriptActivityScriptBlock("@pipeline().parameters.query",DataFactoryScriptType.Query)
                        }
                    }
                },
                Parameters =
                {
                    new KeyValuePair<string, EntityParameterSpecification>("query",new EntityParameterSpecification(EntityParameterType.String))
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_Office365_AzureDataLakeStorage()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            string taskName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = Recording.GenerateAssetName("dataset_");
            string datasetSinkName = Recording.GenerateAssetName("dataset_");

            await CreateDefaultOffice365Dataset(dataFactory, linkedServiceSourceName, datasetSourceName);
            await CreateDefaultAzureDataLakeStoreDataset(dataFactory, linkedServiceSinkName, datasetSinkName);

            DataFactoryPipelineData data = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity(taskName,new Office365Source(),new AzureDataLakeStoreSink())
                    {
                        Source = new Office365Source()
                        {
                            AllowedGroups = new List<string>()
                            {
                                "my_group1",
                                "my_group2",
                                "my_group3"
                            },
                            UserScopeFilterUri = "https://graph.microsoft.com/v1.0/users?$filter=Department eq \"Finance\"",
                            DateFilterColumn = "CreatedDateTime",
                            StartOn = "2019-04-28T16:00:00.000Z",
                            EndOn = "2019-05-05T16:00:00.000Z",
                            OutputColumns = new List<Office365TableOutputColumn>()
                            {
                                new Office365TableOutputColumn("Id"),
                                new Office365TableOutputColumn("CreatedDateTime"),
                            }
                        },
                        Sink = new AzureDataLakeStoreSink()
                        {
                            CopyBehavior = "FlattenHierarchy"
                        },
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName)
                        },
                        LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,linkedServiceSourceName),
                        Policy = new PipelineActivityPolicy()
                        {
                            Retry = 3,
                            Timeout = "00:00:05"
                        }
                    }
                }
            };

            var result = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            Assert.IsNotNull(result.Value.Id);
        }
    }
}
