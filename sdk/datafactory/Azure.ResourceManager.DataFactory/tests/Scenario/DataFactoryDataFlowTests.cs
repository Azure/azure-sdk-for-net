// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        private DataFactoryResource _dataFactory;
        public DataFactoryDataFlowTests(bool isAsync) : base(isAsync)
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
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var subscription = await GlobalClient.GetDefaultSubscriptionAsync();
                    var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    _resourceGroupIdentifier = rgLro.Value.Data.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            string dataFactoryName = Recording.GenerateAssetName("DataFactory-");
            _resourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
            _dataFactory = await CreateDataFactory(_resourceGroup, dataFactoryName);
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

        private async Task<DataFactoryDatasetResource> CreateDefaultAzureSqlDatabaseDataset(string linkedServiceName, string datasetName)
        {
            DataFactoryLinkedServiceData lkSqlSource = new DataFactoryLinkedServiceData(new AzureSqlDatabaseLinkedService("Server=tcp:myServerAddress.database.windows.net,1433;Database=myDataBase;User ID=myUsername;Password=myPassword;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            await _dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkSqlSource);

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureSqlTableDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName)));
            var result = await _dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        [Test]
        [RecordedTest]
        public async Task DataFlow_ExecuteDataFlow()
        {
            string dataFlowName = Recording.GenerateAssetName("task-");
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string linkedServiceSinkName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName1 = Recording.GenerateAssetName("dataset_");
            string datasetSourceName2 = Recording.GenerateAssetName("dataset_");
            string datasetSinkName1 = Recording.GenerateAssetName("dataset_");
            string datasetSinkName2 = Recording.GenerateAssetName("dataset_");

            await CreateDefaultAzureSqlDatabaseDataset(linkedServiceSourceName, datasetSourceName1);
            await CreateDefaultAzureSqlDatabaseDataset(linkedServiceSinkName, datasetSourceName2);
            await CreateDefaultAzureSqlDatabaseDataset(linkedServiceSinkName, datasetSinkName1);
            await CreateDefaultAzureSqlDatabaseDataset(linkedServiceSinkName, datasetSinkName2);

            DataFactoryDataFlowData mappingDataFlowForScriptLines = new DataFactoryDataFlowData(new DataFactoryMappingDataFlowProperties()
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
            var resultForScriptLines = await _dataFactory.GetDataFactoryDataFlows().CreateOrUpdateAsync(WaitUntil.Completed, dataFlowName, mappingDataFlowForScriptLines);
            Assert.NotNull(resultForScriptLines.Value.Id);

            DataFactoryDataFlowData mappingDataFlowForScript = new DataFactoryDataFlowData(new DataFactoryMappingDataFlowProperties()
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
            var resultForScript = await _dataFactory.GetDataFactoryDataFlows().CreateOrUpdateAsync(WaitUntil.Completed, dataFlowName, mappingDataFlowForScript);
            Assert.NotNull(resultForScript.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Pipeline_ExecuteWarnglingDataflow_Queries()
        {
            string taskPowerQueryName = "powerquery1";
            string linkedServiceSourceName = Recording.GenerateAssetName("linkedService_");
            string datasetSourceName = "DS_AzureSqlDatabase1";
            string datasetSinkName = "DS_AzureSqlDatabase2";

            await CreateDefaultAzureSqlDatabaseDataset(datasetSourceName, datasetSourceName);
            await CreateDefaultAzureSqlDatabaseDataset(linkedServiceSourceName, datasetSinkName);

            DataFactoryDataFlowData mapping = new DataFactoryDataFlowData(new DataFactoryWranglingDataFlowProperties()
            {
                Sources =
                {
                    new PowerQuerySource(datasetSourceName)
                    {
                        Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSourceName),
                        Script = "source(allowSchemaDrift: true,\n\tvalidateSchema: false,\n\tisolationLevel: 'READ_UNCOMMITTED',\n\tformat: 'table') ~>  DS_AzureSqlDatabase1"
                    },
                    new PowerQuerySource(datasetSinkName)
                    {
                        Dataset = new DatasetReference(DatasetReferenceType.DatasetReference,datasetSinkName),
                        Script = "source(allowSchemaDrift: true,\n\tvalidateSchema: false,\n\tisolationLevel: 'READ_UNCOMMITTED',\n\tformat: 'table') ~>  DS_AzureSqlDatabase1"
                    }
                },
                Script = "section Section1;\r\nshared DS_AzureSqlDatabase1 = let AdfDoc = Sql.Database(\"**********\", \"**********\", [CreateNavigationProperties = false]), InputTable = AdfDoc{[Schema=\"undefined\",Item=\"undefined\"]}[Data] in InputTable;\r\nshared UserQuery = let Source = #\"DS_AzureSqlDatabase1\" in Source;\r\n",
                DocumentLocale = "de-DE"
            });
            var result = await _dataFactory.GetDataFactoryDataFlows().CreateOrUpdateAsync(WaitUntil.Completed, taskPowerQueryName, mapping);
            Assert.NotNull(result.Value.Id);
        }
    }
}
