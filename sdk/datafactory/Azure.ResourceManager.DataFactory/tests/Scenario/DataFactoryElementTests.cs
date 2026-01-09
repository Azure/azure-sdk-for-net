// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryElementTests : DataFactoryManagementTestBase
    {
        public DataFactoryElementTests(bool isAsync) : base(isAsync)
        {
        }

        public async Task<DataFactoryResource> TestSetUp()
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName($"adf-rg-element-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"adf-element-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);
            Assert.That(dataFactory.Data.Id, Is.Not.Null);
            return dataFactory;
        }

        [Test]
        [RecordedTest]
        public async Task CreateLinkedServiceFromSecretString()
        {
            DataFactoryResource dataFactory = await TestSetUp();
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
            Assert.Multiple(() =>
            {
                Assert.That(linkedService, Is.Not.Null);
                Assert.That(element, Is.Not.Null);
            });
            AssertStringDataFactoryElement(element, "**********", DataFactoryElementKind.Literal);
            Assert.That(element.ToString(), Is.EqualTo("**********"));
        }

        [Test]
        [RecordedTest]
        public async Task CreateLinkedServiceFromLiteral()
        {
            DataFactoryResource dataFactory = await TestSetUp();
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
            Assert.Multiple(() =>
            {
                Assert.That(linkedService, Is.Not.Null);
                Assert.That(element, Is.Not.Null);
            });
            AssertStringDataFactoryElement(element, connectionStringExpected, DataFactoryElementKind.Literal);
            Assert.That(element.ToString(), Is.EqualTo(connectionStringExpected));
        }

        [Test]
        [RecordedTest]
        public async Task CreateDataSetFromExpression()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=1234567890;EndpointSuffix=core.windows.net";
            var azureBlobStorageLinkedServiceName = Recording.GenerateAssetName("LinkedService");
            var azureBlobStorageLinkedService = await CreateAzureBlobStorageLinkedService(dataFactory, azureBlobStorageLinkedServiceName, connectionString);

            DataFactoryLinkedServiceReference dataFactoryLinkedServiceReference = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference, azureBlobStorageLinkedServiceName);
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
            Assert.Multiple(() =>
            {
                Assert.That(elementContainer, Is.Not.Null);
                Assert.That(elementFileName, Is.Not.Null);
            });
            AssertStringDataFactoryElement(elementContainer, "@guid()", DataFactoryElementKind.Literal);
            Assert.That(elementContainer.ToString(), Is.EqualTo("@guid()"));

            AssertStringDataFactoryElement(elementFileName, "@utcnow()", DataFactoryElementKind.Literal);
            Assert.That(elementFileName.ToString(), Is.EqualTo("@utcnow()"));
        }

        [Test]
        [RecordedTest]
        public async Task CreateLinkedServiceFromKeyVaultSecret()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string linkedServiceAKVName = Recording.GenerateAssetName("LinkedService");
            string linkedServiceAzureSQLName = Recording.GenerateAssetName("LinkedService");
            string baseUri = "https://adms-test-kv.vault.azure.net/";
            AzureKeyVaultLinkedService azureKeyVaultLinkedService = new AzureKeyVaultLinkedService(baseUri);
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(azureKeyVaultLinkedService);
            var resultAKV = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(Azure.WaitUntil.Completed, linkedServiceAKVName, data);

            var store = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference, linkedServiceAKVName);
            var keyVaultReference = new DataFactoryKeyVaultSecret(store, "AzureSDKTest");
            var service = new AzureSqlDatabaseLinkedService(DataFactoryElement<string>.FromKeyVaultSecret(keyVaultReference));
            DataFactoryLinkedServiceData data1 = new DataFactoryLinkedServiceData(service);
            var linkedService = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(Azure.WaitUntil.Completed, linkedServiceAzureSQLName, data1);
            var response = linkedService.WaitForCompletionResponseAsync().Result.Content.ToString();
            var jsonCon = JsonSerializer.Deserialize<DataFactoryElementTestCollection>(response);

            DataFactoryElement<string> element = jsonCon.JsonProperties.JsonTypeProperties.ConnectionString.ToString();
            Assert.Multiple(() =>
            {
                Assert.That(linkedService, Is.Not.Null);
                Assert.That(element, Is.Not.Null);
            });
            AssertStringDataFactoryElement(element, "AzureSDKTest", DataFactoryElementKind.Literal);
            Assert.That(element.ToString(), Is.EqualTo("AzureSDKTest"));
        }

        private static void AssertStringDataFactoryElement(DataFactoryElement<string> dfe, string expectedValue, DataFactoryElementKind expectedKind)
        {
            Assert.Multiple(() =>
            {
                Assert.That(dfe.Kind, Is.EqualTo(expectedKind));
                Assert.That(dfe.ToString(), Is.EqualTo(expectedValue));
            });
        }
    }
}
