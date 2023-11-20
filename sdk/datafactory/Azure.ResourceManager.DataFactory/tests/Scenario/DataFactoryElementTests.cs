// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryElementTests : DataFactoryManagementTestBase
    {
        public DataFactoryElementTests(bool isAsync) : base(isAsync)
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

        [Test]
        [RecordedTest]
        public async Task CreateLinkedServiceFromSecretString()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=1234567890;EndpointSuffix=core.windows.net";

            AzureBlobStorageLinkedService azureBlobStorageLinkedService = new AzureBlobStorageLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString(connectionString)
            };
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(azureBlobStorageLinkedService);
            var linkedService = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            var response = linkedService.WaitForCompletionResponseAsync().Result.Content.ToString();
            var jsonCon = JsonSerializer.Deserialize<DataFactoryElementTestCollection>(response);

            DataFactoryElement<string> element = jsonCon.JsonProperties.JsonTypeProperties.ConnectionString.ToString();
            Assert.IsNotNull(linkedService);
            Assert.IsNotNull(element);
            AssertStringDataFactoryElement(element, "**********", DataFactoryElementKind.Literal);
            Assert.AreEqual("**********", element.ToString());
        }

        [Test]
        [RecordedTest]
        public async Task CreateLinkedServiceFromLiteral()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=1234567890;EndpointSuffix=core.windows.net";
            string connectionStringExpected = "Sanitized";

            AzureBlobStorageLinkedService azureBlobStorageLinkedService = new AzureBlobStorageLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromLiteral(connectionString)
            };
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(azureBlobStorageLinkedService);
            var linkedService = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            var response = linkedService.WaitForCompletionResponseAsync().Result.Content.ToString();
            var jsonCon = JsonSerializer.Deserialize<DataFactoryElementTestCollection>(response);

            DataFactoryElement<string> element = jsonCon.JsonProperties.JsonTypeProperties.ConnectionString.ToString();
            Assert.IsNotNull(linkedService);
            Assert.IsNotNull(element);
            AssertStringDataFactoryElement(element, connectionStringExpected, DataFactoryElementKind.Literal);
            Assert.AreEqual(connectionStringExpected, element.ToString());
        }

        [Test]
        [RecordedTest]
        public async Task CreateDataSetFromExpression()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=1234567890;EndpointSuffix=core.windows.net";
            var azureBlobStorageLinkedServiceName = Recording.GenerateAssetName("LinkedService");
            var azureBlobStorageLinkedService = await CreateAzureBlobStorageLinkedService(dataFactory, azureBlobStorageLinkedServiceName, connectionString);

            DataFactoryLinkedServiceReference dataFactoryLinkedServiceReference = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, azureBlobStorageLinkedServiceName);
            DelimitedTextDataset delimitedTextDataset = new DelimitedTextDataset(dataFactoryLinkedServiceReference)
            {
                Schema = new List<DatasetSchemaDataElement>()
                {
                    new DatasetSchemaDataElement(){ SchemaColumnName = "Id",SchemaColumnType="String"},
                    new DatasetSchemaDataElement(){ SchemaColumnName = "Content",SchemaColumnType="String"}
                },
                DataLocation = new AzureBlobStorageLocation()
                {
                    Container = DataFactoryElement<string>.FromExpression("@guid()"),
                    FileName = DataFactoryElement<string>.FromExpression("@utcnow()")
                },
                ColumnDelimiter = ",",
                FirstRowAsHeader = true
            };

            DataFactoryDatasetData data = new DataFactoryDatasetData(delimitedTextDataset);
            var dataSet = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(Azure.WaitUntil.Completed, "TestSDK", data);
            var response = dataSet.WaitForCompletionResponseAsync().Result.Content.ToString();
            var jsonCon = JsonSerializer.Deserialize<DataFactoryElementTestCollection>(response);

            DataFactoryElement<string> elementContainer = jsonCon.JsonProperties.JsonTypeProperties.Location.Container.ToString();
            DataFactoryElement<string> elementFileName = jsonCon.JsonProperties.JsonTypeProperties.Location.FileName.ToString();
            Assert.IsNotNull(elementContainer);
            Assert.IsNotNull(elementFileName);
            AssertStringDataFactoryElement(elementContainer, "@guid()", DataFactoryElementKind.Literal);
            Assert.AreEqual("@guid()", elementContainer.ToString());

            AssertStringDataFactoryElement(elementFileName, "@utcnow()", DataFactoryElementKind.Literal);
            Assert.AreEqual("@utcnow()", elementFileName.ToString());
        }

        [Test]
        [RecordedTest]
        public async Task CreateLinkedServiceFromKeyVaultSecret()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceAKVName = Recording.GenerateAssetName("LinkedService");
            string linkedServiceAzureSQLName = Recording.GenerateAssetName("LinkedService");
            string baseUri = "https://adms-test-kv.vault.azure.net/";
            AzureKeyVaultLinkedService azureKeyVaultLinkedService = new AzureKeyVaultLinkedService(baseUri);
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(azureKeyVaultLinkedService);
            var resultAKV = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(Azure.WaitUntil.Completed, linkedServiceAKVName, data);

            var store = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceAKVName);
            var keyVaultReference = new DataFactoryKeyVaultSecretReference(store, "AzureSDKTest");
            var service = new AzureSqlDatabaseLinkedService(DataFactoryElement<string>.FromKeyVaultSecretReference(keyVaultReference));
            DataFactoryLinkedServiceData data1 = new DataFactoryLinkedServiceData(service);
            var linkedService = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(Azure.WaitUntil.Completed, linkedServiceAzureSQLName, data1);
            var response = linkedService.WaitForCompletionResponseAsync().Result.Content.ToString();
            var jsonCon = JsonSerializer.Deserialize<DataFactoryElementTestCollection>(response);

            DataFactoryElement<string> element = jsonCon.JsonProperties.JsonTypeProperties.ConnectionString.ToString();
            Assert.IsNotNull(linkedService);
            Assert.IsNotNull(element);
            AssertStringDataFactoryElement(element, "AzureSDKTest", DataFactoryElementKind.Literal);
            Assert.AreEqual("AzureSDKTest", element.ToString());
        }

        private static void AssertStringDataFactoryElement(DataFactoryElement<string> dfe, string expectedValue, DataFactoryElementKind expectedKind)
        {
            Assert.AreEqual(expectedKind, dfe.Kind);
            Assert.AreEqual(expectedValue, dfe.ToString());
        }
    }
}
