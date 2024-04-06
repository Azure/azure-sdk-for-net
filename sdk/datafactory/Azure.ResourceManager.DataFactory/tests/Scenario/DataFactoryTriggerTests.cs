// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryTriggerTests : DataFactoryManagementTestBase
    {
        public DataFactoryTriggerTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<DataFactoryPipelineResource> CreateDefaultEmptyPipeLine(DataFactoryResource dataFactory, string pipelineName)
        {
            DataFactoryPipelineData data = new DataFactoryPipelineData() { };
            var pipeline = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            return pipeline.Value;
        }

        private async Task<DataFactoryTriggerResource> CreateDefaultTrigger(DataFactoryResource dataFactory, string triggerName)
        {
            string pipelineName1 = Recording.GenerateAssetName("pipeline-");

            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName1);

            ScheduleTriggerRecurrence recurrence = new ScheduleTriggerRecurrence()
            {
                Frequency = "Month",
                Interval = 1,
                TimeZone = "UTC",
                StartOn = DateTimeOffset.Parse("2017-04-14T13:00:00Z"),
                EndOn = DateTimeOffset.Parse("2018-04-14T13:00:00Z")
            };
            DataFactoryTriggerData data = new DataFactoryTriggerData(new DataFactoryScheduleTrigger(recurrence)
            {
                Pipelines =
                {
                    new TriggerPipelineReference()
                    {
                        PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName1),
                    }
                }
            });
            var result = await dataFactory.GetDataFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, data);
            return result.Value;
        }

        private async Task<DataFactoryTriggerResource> CreateDefaultTumblingWindowTrigger(DataFactoryResource dataFactory, string triggerName)
        {
            string pipelineName = Recording.GenerateAssetName("pipeline-");
            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName);

            TriggerPipelineReference references = new TriggerPipelineReference()
            {
                PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName),
            };

            DataFactoryTriggerData dataTrigger = new DataFactoryTriggerData(new TumblingWindowTrigger(references, TumblingWindowFrequency.Hour, 12, DateTimeOffset.Parse("2023-10-31T00:00:00Z"), 50));
            var result = await dataFactory.GetDataFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, dataTrigger);
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

            DataFactoryDatasetData data = new DataFactoryDatasetData(new AzureBlobDataset(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference, linkedServiceName)));
            var result = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, datasetName, data);
            return result.Value;
        }

        private async Task TriggerCreate(string name, Func<DataFactoryResource, string, string, string, string, DataFactoryTriggerData> triggerFunc)
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName("adf-rg-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a data factory
            string dataFactoryName = Recording.GenerateAssetName("adf-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);
            // Create a trigger
            string triggerName = Recording.GenerateAssetName("trigger-");
            string linkedServiceName = Recording.GenerateAssetName("linkedService_");
            string pipelineName1 = Recording.GenerateAssetName("pipeline-");
            string pipelineName2 = Recording.GenerateAssetName("pipeline-");
            string pipelineName3 = Recording.GenerateAssetName("pipeline-");

            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName1);
            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName2);
            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName3);

            DataFactoryLinkedServiceData lkBlobSource = new DataFactoryLinkedServiceData(new AzureBlobStorageLinkedService()
            {
                ConnectionString = "DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net"
            });
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkBlobSource);

            var result = await dataFactory.GetDataFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, triggerFunc(dataFactory, linkedServiceName, pipelineName1, pipelineName2, pipelineName3));
            Assert.IsNotNull(result.Value.Data.Id);
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_Create_Exists_Get_List_Delete()
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName("adf-rg-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName("adf-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);
            // Create
            string triggerName = Recording.GenerateAssetName("trigger-");
            var trigger = await CreateDefaultTrigger(dataFactory, triggerName);
            Assert.IsNotNull(trigger);
            Assert.AreEqual(triggerName, trigger.Data.Name);
            // Exists
            bool flag = await dataFactory.GetDataFactoryTriggers().ExistsAsync(triggerName);
            Assert.IsTrue(flag);
            // Get
            var triggerGet = await dataFactory.GetDataFactoryTriggers().GetAsync(triggerName);
            Assert.IsNotNull(trigger);
            Assert.AreEqual(triggerName, triggerGet.Value.Data.Name);
            // GetAll
            var list = await dataFactory.GetDataFactoryTriggers().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            // Delete
            await trigger.DeleteAsync(WaitUntil.Completed);
            flag = await dataFactory.GetDataFactoryTriggers().ExistsAsync(triggerName);
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_BlobTrigger_Create()
        {
            await TriggerCreate("blobtrigger", (DataFactoryResource dataFactory, string linkedServiceName, string pipelineName1, string pipelineName2, string pipelineName3) =>
            {
                return new DataFactoryTriggerData(new DataFactoryBlobTrigger("blobtriggertestpath", 10, new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference, linkedServiceName))
                {
                    MaxConcurrency = 10,
                    Pipelines =
                    {
                        new TriggerPipelineReference()
                        {
                            PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName1),
                            Parameters =
                            {
                                new KeyValuePair<string, System.BinaryData>("mySinkDatasetFolderPath",BinaryData.FromString("\"blobtriggertestoutput\"")),
                                new KeyValuePair<string, System.BinaryData>("mySourceDatasetFolderPath",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@split(triggerBody().path, '/')[1]"))),
                                new KeyValuePair<string, System.BinaryData>("mySourceDatasetFilePath",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@split(triggerBody().path, '/')[2]"))),
                            }
                        },
                        new TriggerPipelineReference(){ PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName2)},
                        new TriggerPipelineReference(){ PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName3)}
                    }
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_BlobEventsTrigger_Create()
        {
            await TriggerCreate("blobeventtrigger", (DataFactoryResource dataFactory, string linkedServiceName, string pipelineName1, string pipelineName2, string pipelineName3) =>
            {
                return new DataFactoryTriggerData(new DataFactoryBlobEventsTrigger(new List<DataFactoryBlobEventType>() {
                DataFactoryBlobEventType.MicrosoftStorageBlobCreated,
                DataFactoryBlobEventType.MicrosoftStorageBlobDeleted
                }, "/subscriptions/da1d7b9a-a759-41c8-bb73-093a1818e03a/resourceGroups/AzureSDKTest/providers/Microsoft.Storage/storageAccounts/testazuresdkstorage")
                {
                    Pipelines =
                        {
                            new TriggerPipelineReference()
                            {
                                PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName1),
                                Parameters =
                                {
                                    new KeyValuePair<string, BinaryData>("mySinkDatasetFolderPath",BinaryData.FromString("\"sinkcontainer\"")),
                                    new KeyValuePair<string, BinaryData>("mySourceDatasetFolderPath",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@triggerBody().folderPath"))),
                                    new KeyValuePair<string, BinaryData>("mySourceDatasetFilePath",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@triggerBody().fileName"))),
                                }
                            },
                            new TriggerPipelineReference(){ PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName2)},
                            new TriggerPipelineReference(){ PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName3)}
                        }
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_ScheduleTrigger_Create()
        {
            await TriggerCreate("scheduletrigger", (DataFactoryResource dataFactory, string linkedServiceName, string pipelineName1, string pipelineName2, string pipelineName3) =>
            {
                ScheduleTriggerRecurrence recurrence = new ScheduleTriggerRecurrence()
                {
                    Frequency = "Month",
                    Interval = 1,
                    TimeZone = "UTC",
                    StartOn = DateTimeOffset.Parse("2017-04-14T13:00:00Z"),
                    EndOn = DateTimeOffset.Parse("2018-04-14T13:00:00Z")
                };
                return new DataFactoryTriggerData(new DataFactoryScheduleTrigger(recurrence)
                {
                    Pipelines =
                    {
                        new TriggerPipelineReference()
                        {
                            PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName1),
                            Parameters =
                            {
                                new KeyValuePair<string, BinaryData>("mySinkDatasetFolderPath",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{concat('output',formatDateTime(trigger().startTime,'-dd-MM-yyyy-HH-mm-ss-ffff'))}"))),
                                new KeyValuePair<string, BinaryData>("mySourceDatasetFolderPath",BinaryData.FromString("\"input/\""))
                            }
                        },
                        new TriggerPipelineReference(){ PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName2)},
                        new TriggerPipelineReference(){ PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName3)}
                    }
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_TumblingWindowTrigger_Hour_Create()
        {
            await TriggerCreate("tumblingwindowtrigger", (DataFactoryResource dataFactory, string linkedServiceName, string pipelineName1, string pipelineName2, string pipelineName3) =>
            {
                TriggerPipelineReference references = new TriggerPipelineReference()
                {
                    PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName1),
                    Parameters =
                    {
                        new KeyValuePair<string, BinaryData>("windowStart",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{trigger().outputs.windowStartTime}"))),
                        new KeyValuePair<string, BinaryData>("windowEnd",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{trigger().outputs.windowEndTime}"))),
                    }
                };
                return new DataFactoryTriggerData(new TumblingWindowTrigger(references, TumblingWindowFrequency.Hour, 3, DateTimeOffset.Parse("2017-04-14T13:00:00Z"), 10)
                {
                    Delay = "00:00:01",
                    RetryPolicy = new RetryPolicy()
                    {
                        Count = 3,
                        IntervalInSeconds = 30
                    }
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_TumblingWindowTrigger_Month_Create()
        {
            await TriggerCreate("tumblingwindowtrigger", (DataFactoryResource dataFactory, string linkedServiceName, string pipelineName1, string pipelineName2, string pipelineName3) =>
            {
                TriggerPipelineReference references = new TriggerPipelineReference()
                {
                    PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName1),
                    Parameters =
                    {
                        new KeyValuePair<string, BinaryData>("windowStart",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{trigger().outputs.windowStartTime}"))),
                        new KeyValuePair<string, BinaryData>("windowEnd",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{trigger().outputs.windowEndTime}"))),
                    }
                };
                return new DataFactoryTriggerData(new TumblingWindowTrigger(references, TumblingWindowFrequency.Month, 3, DateTimeOffset.Parse("2017-04-14T13:00:00Z"), 10)
                {
                    Delay = "00:00:01",
                    RetryPolicy = new RetryPolicy()
                    {
                        Count = 3,
                        IntervalInSeconds = 30
                    }
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_TumblingWindowTrigger_Dependency_Create()
        {
            await TriggerCreate("tumblingwindowtrigger", (DataFactoryResource dataFactory, string linkedServiceName, string pipelineName1, string pipelineName2, string pipelineName3) =>
            {
                string referenceTriggerName = Recording.GenerateAssetName("trigger-");
                _ = CreateDefaultTumblingWindowTrigger(dataFactory, referenceTriggerName).Result;
                TriggerPipelineReference references = new TriggerPipelineReference()
                {
                    PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName1),
                    Parameters =
                    {
                        new KeyValuePair<string, BinaryData>("windowStart",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{trigger().outputs.windowStartTime}"))),
                        new KeyValuePair<string, BinaryData>("windowEnd",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{trigger().outputs.windowEndTime}"))),
                    }
                };
                return new DataFactoryTriggerData(new TumblingWindowTrigger(references, TumblingWindowFrequency.Month, 24, DateTimeOffset.Parse("2017-04-14T13:00:00Z"), 10)
                {
                    Delay = "00:00:01",
                    RetryPolicy = new RetryPolicy()
                    {
                        Count = 3,
                        IntervalInSeconds = 30
                    },
                    DependsOn =
                    {
                        new TumblingWindowTriggerDependencyReference(new DataFactoryTriggerReference(DataFactoryTriggerReferenceType.TriggerReference,referenceTriggerName))
                        {
                            Offset = "00:00:00",
                            Size = "02:00:00"
                        },
                        new TumblingWindowTriggerDependencyReference(new DataFactoryTriggerReference(DataFactoryTriggerReferenceType.TriggerReference,referenceTriggerName))
                        {
                            Offset = "00:00:00",
                            Size = "02:00:00"
                        }
                    }
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_CustomEventsTrigger_Create()
        {
            await TriggerCreate("customeventstrigger", (DataFactoryResource dataFactory, string linkedServiceName, string pipelineName1, string pipelineName2, string pipelineName3) =>
            {
                return new DataFactoryTriggerData(new CustomEventsTrigger(new List<BinaryData>() { BinaryData.FromString("\"Microsoft.Storage.BlobCreated\"") }, "/subscriptions/b371d9e7-d3c2-4b1a-83ec-84e1f50c2222")
                {
                    SubjectBeginsWith = "B",
                    SubjectEndsWith = "E",
                    Events =
                    {
                        BinaryData.FromString("\"123\"")
                    }
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_RerunTumblingWindowTrigger_Create()
        {
            await TriggerCreate("returntumblingwindowtrigger", (DataFactoryResource dataFactory, string linkedServiceName, string pipelineName1, string pipelineName2, string pipelineName3) =>
            {
                string referenceTriggerName = Recording.GenerateAssetName("trigger-");
                _ = CreateDefaultTumblingWindowTrigger(dataFactory, referenceTriggerName).Result;
                var state1 = dataFactory.GetDataFactoryTriggerAsync(referenceTriggerName).Result;
                _ = state1.Value.StartAsync(WaitUntil.Completed).Result;
                return new DataFactoryTriggerData(new RerunTumblingWindowTrigger(
                BinaryData.FromString($"{{\"type\": \"TriggerReference\",\"referenceName\": \"{referenceTriggerName}\"}}"),
                DateTimeOffset.Parse("2023-11-01T00:00:00.0000000Z"),
                DateTimeOffset.Parse("2023-11-02T12:00:00.0000000Z"), 50));
            });
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_TriggerRun_Create()
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName("adf-rg-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a data factory
            string dataFactoryName = Recording.GenerateAssetName("adf-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);

            string referenceTriggerName = Recording.GenerateAssetName("trigger-");
            await CreateDefaultTumblingWindowTrigger(dataFactory, referenceTriggerName);
            var state = await dataFactory.GetDataFactoryTriggerAsync(referenceTriggerName);
            await state.Value.StartAsync(WaitUntil.Completed);
            var list = dataFactory.GetTriggerRunsAsync(new RunFilterContent(DateTimeOffset.Parse("2017-04-14T13:00:00Z"), DateTimeOffset.Parse("2030-04-14T13:00:00Z")));

            await foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
