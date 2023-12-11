// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    internal class DataFactoryDataFlowTests : DataFactoryManagementTestBase
    {
        public DataFactoryDataFlowTests(bool isAsync) : base(isAsync)
        {
        }

        public async Task DataFlowCreate(string name, Func<DataFactoryResource, string, string, string, string, DataFactoryDataFlowData> dataflowFunc)
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName($"adf-rg-{name}-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"adf-{name}-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);

            string dataFlowName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName1 = Recording.GenerateAssetName("dataset_");
            string datasetSourceName2 = Recording.GenerateAssetName("dataset_");
            string datasetSinkName1 = Recording.GenerateAssetName("dataset_");
            string datasetSinkName2 = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSourceName, datasetSourceName1);
            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSinkName, datasetSourceName2);
            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSinkName, datasetSinkName1);
            await CreateDefaultAzureSqlDatabaseDataset(dataFactory, linkedServiceSinkName, datasetSinkName2);

            var result = await dataFactory.GetDataFactoryDataFlows().CreateOrUpdateAsync(WaitUntil.Completed, dataFlowName, dataflowFunc(dataFactory, datasetSourceName1, datasetSourceName2, datasetSinkName1, datasetSinkName2));
            Assert.NotNull(result.Value.Id);
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAzureSqlDatabaseDataset(DataFactoryResource dataFactory, string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSqlSource = new DataFactoryLinkedServiceData(new AzureSqlDatabaseLinkedService("Server=tcp:myServerAddress.database.windows.net,1433;Database=myDataBase;User ID=myUsername;Password=myPassword;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSqlSource);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task DataFlow_ExecuteDataFlow_Create()
        {
            await DataFlowCreate("dataflow", (DataFactoryResource dataFactory, string datasetSourceName1, string datasetSourceName2, string datasetSinkName1, string datasetSinkName2) =>
            {
                return new DataFactoryDataFlowData(new DataFactoryMappingDataFlowProperties()
                {
                    Sources =
                    {
                        new DataFlowSource(datasetSourceName1)
                        {
                            Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName1)
                        },
                        new DataFlowSource(datasetSourceName2)
                        {
                            Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName2)
                        }
                    },
                    Sinks =
                    {
                        new DataFlowSink(datasetSinkName1)
                        {
                            Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName1)
                        },
                        new DataFlowSink(datasetSinkName2)
                        {
                            Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName2)
                        }
                    },
                    Script = "fake some script",
                    ScriptLines =
                    {
                        "some script1",
                        "some script2"
                    }
                });
            });

            await DataFlowCreate("dataflow", (DataFactoryResource dataFactory, string datasetSourceName1, string datasetSourceName2, string datasetSinkName1, string datasetSinkName2) =>
            {
                return new DataFactoryDataFlowData(new DataFactoryMappingDataFlowProperties()
                {
                    Sources =
                    {
                        new DataFlowSource(datasetSourceName1)
                        {
                            Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName1)
                        },
                        new DataFlowSource(datasetSourceName2)
                        {
                            Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName2)
                        }
                    },
                    Sinks =
                    {
                        new DataFlowSink(datasetSinkName1)
                        {
                            Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName1)
                        },
                        new DataFlowSink(datasetSinkName2)
                        {
                            Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName2)
                        }
                    },
                    Script = "fake some script"
                });
            });
        }
    }
}
