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

        public async Task<DataFactoryResource> TestSetUp()
        {
            string rgName = Recording.GenerateAssetName("DataFactory-RG-");
            string dataFactoryName = Recording.GenerateAssetName("DataFactory-");
            var subscription = await Client.GetDefaultSubscriptionAsync();
            var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            return await CreateDataFactory((Client.GetResourceGroupResource(rgLro.Value.Data.Id)), dataFactoryName);
        }

        private async Task<DataFactoryTriggerResource> CreateDefaultTrigger(DataFactoryResource dataFactory, string triggerName)
        {
            string pipelineName1 = Recording.GenerateAssetName("pipeline-");

            await CreateDefaultEmptyPipeLine(dataFactory,pipelineName1);

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

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");
            var trigger = await CreateDefaultTrigger(dataFactory, triggerName);
            Assert.IsNotNull(trigger);
            Assert.AreEqual(triggerName, trigger.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");
            await CreateDefaultTrigger(dataFactory, triggerName);
            bool flag = await dataFactory.GetDataFactoryTriggers().ExistsAsync(triggerName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");
            await CreateDefaultTrigger(dataFactory, triggerName);
            var trigger = await dataFactory.GetDataFactoryTriggers().GetAsync(triggerName);
            Assert.IsNotNull(trigger);
            Assert.AreEqual(triggerName, trigger.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");
            await CreateDefaultTrigger(dataFactory, triggerName);
            var list = await dataFactory.GetDataFactoryTriggers().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");
            var trigger = await CreateDefaultTrigger(dataFactory, triggerName);
            bool flag = await dataFactory.GetDataFactoryTriggers().ExistsAsync(triggerName);
            Assert.IsTrue(flag);

            await trigger.DeleteAsync(WaitUntil.Completed);
            flag = await dataFactory.GetDataFactoryTriggers().ExistsAsync(triggerName);
            Assert.IsFalse(flag);
        }

        private async Task<DataFactoryPipelineResource> CreateDefaultEmptyPipeLine(DataFactoryResource dataFactory, string pipelineName)
        {
            DataFactoryPipelineData data = new DataFactoryPipelineData() { };
            var pipeline = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            return pipeline.Value;
        }

        private async Task<DataFactoryDatasetResource> CreateDefaultAzureBlobStorageLinkedServiceOrDatasets(string linkedServiceName, string datasetName)
        {
            DataFactoryResource dataFactory = await TestSetUp();
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

        [Test]
        [RecordedTest]
        public async Task Trigger_ChainingTrigger()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");
            string pipelineName1 = Recording.GenerateAssetName("pipeline-");
            string pipelineName2 = Recording.GenerateAssetName("pipeline-");
            string pipelineName3 = Recording.GenerateAssetName("pipeline-");

            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName1);
            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName2);
            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName3);

            TriggerPipelineReference reference = new TriggerPipelineReference()
            {
                PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName1)
            };
            DataFactoryTriggerData data = new DataFactoryTriggerData(new ChainingTrigger(reference, new List<DataFactoryPipelineReference>()
            {
                new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference,pipelineName2)
            }, ""));
            var result = await dataFactory.GetDataFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, data);
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_BlobTrigger()
        {
            DataFactoryResource dataFactory = await TestSetUp();
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

            TriggerPipelineReference reference = new TriggerPipelineReference()
            {
                PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName1)
            };
            DataFactoryTriggerData data = new DataFactoryTriggerData(new DataFactoryBlobTrigger("blobtriggertestpath", 10, new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceName))
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
            var result = await dataFactory.GetDataFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, data);
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_BlobEventsTrigger()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");
            string pipelineName1 = Recording.GenerateAssetName("pipeline-");
            string pipelineName2 = Recording.GenerateAssetName("pipeline-");
            string pipelineName3 = Recording.GenerateAssetName("pipeline-");

            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName1);
            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName2);
            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName3);

            DataFactoryTriggerData data = new DataFactoryTriggerData(new DataFactoryBlobEventsTrigger(new List<DataFactoryBlobEventType>() {
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
            var result = await dataFactory.GetDataFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, data);
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_ScheduleTrigger()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");
            string pipelineName1 = Recording.GenerateAssetName("pipeline-");
            string pipelineName2 = Recording.GenerateAssetName("pipeline-");
            string pipelineName3 = Recording.GenerateAssetName("pipeline-");

            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName1);
            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName2);
            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName3);

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
            var result = dataFactory.GetDataFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, data);
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_TumblingWindowTrigger_Hour()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName);

            TriggerPipelineReference references = new TriggerPipelineReference()
            {
                PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName),
                Parameters =
                {
                    new KeyValuePair<string, BinaryData>("windowStart",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{trigger().outputs.windowStartTime}"))),
                    new KeyValuePair<string, BinaryData>("windowEnd",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{trigger().outputs.windowEndTime}"))),
                }
            };

            DataFactoryTriggerData data = new DataFactoryTriggerData(new TumblingWindowTrigger(references, TumblingWindowFrequency.Hour, 3, DateTimeOffset.Parse("2017-04-14T13:00:00Z"), 10)
            {
                Delay = "00:00:01",
                RetryPolicy = new RetryPolicy()
                {
                    Count = 3,
                    IntervalInSeconds = 30
                }
            });
            var result = dataFactory.GetDataFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, data);
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_TumblingWindowTrigger_Month()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName);

            TriggerPipelineReference references = new TriggerPipelineReference()
            {
                PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName),
                Parameters =
                {
                    new KeyValuePair<string, BinaryData>("windowStart",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{trigger().outputs.windowStartTime}"))),
                    new KeyValuePair<string, BinaryData>("windowEnd",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{trigger().outputs.windowEndTime}"))),
                }
            };

            DataFactoryTriggerData data = new DataFactoryTriggerData(new TumblingWindowTrigger(references, TumblingWindowFrequency.Month, 3, DateTimeOffset.Parse("2017-04-14T13:00:00Z"), 10)
            {
                Delay = "00:00:01",
                RetryPolicy = new RetryPolicy()
                {
                    Count = 3,
                    IntervalInSeconds = 30
                }
            });
            var result = await dataFactory.GetDataFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, data);
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_TumblingWindowTrigger_Dependency()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");
            string referenceTriggerName = Recording.GenerateAssetName("trigger-");
            string pipelineName = Recording.GenerateAssetName("pipeline-");

            await CreateDefaultEmptyPipeLine(dataFactory, pipelineName);
            await CreateDefaultTumblingWindowTrigger(dataFactory, referenceTriggerName);

            TriggerPipelineReference references = new TriggerPipelineReference()
            {
                PipelineReference = new DataFactoryPipelineReference(DataFactoryPipelineReferenceType.PipelineReference, pipelineName),
                Parameters =
                {
                    new KeyValuePair<string, BinaryData>("windowStart",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{trigger().outputs.windowStartTime}"))),
                    new KeyValuePair<string, BinaryData>("windowEnd",BinaryData.FromObjectAsJson<DataFactoryElement<string>>(DataFactoryElement<string>.FromExpression("@{trigger().outputs.windowEndTime}"))),
                }
            };

            DataFactoryTriggerData data = new DataFactoryTriggerData(new TumblingWindowTrigger(references, TumblingWindowFrequency.Month, 24, DateTimeOffset.Parse("2017-04-14T13:00:00Z"), 10)
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
            var result = await dataFactory.GetDataFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, data);
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_CustomEventsTrigger()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");

            DataFactoryTriggerData data = new DataFactoryTriggerData(new CustomEventsTrigger(new List<BinaryData>() { BinaryData.FromString("\"Microsoft.Storage.BlobCreated\"") }, "/subscriptions/b371d9e7-d3c2-4b1a-83ec-84e1f50c2222")
            {
                SubjectBeginsWith = "B",
                SubjectEndsWith = "E",
                Events =
                {
                    BinaryData.FromString("\"123\"")
                }
            });
            var result = await dataFactory.GetDataFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, data);
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_RerunTumblingWindowTrigger()
        {
            DataFactoryResource dataFactory = await TestSetUp();
            string triggerName = Recording.GenerateAssetName("trigger-");
            string referenceTriggerName = Recording.GenerateAssetName("trigger-");
            await CreateDefaultTumblingWindowTrigger(dataFactory, referenceTriggerName);
            var state1 = await dataFactory.GetDataFactoryTriggerAsync(referenceTriggerName);
            await state1.Value.StartAsync(WaitUntil.Completed);
            DataFactoryTriggerData data = new DataFactoryTriggerData(new RerunTumblingWindowTrigger(
                BinaryData.FromString($"{{\"type\": \"TriggerReference\",\"referenceName\": \"{referenceTriggerName}\"}}"),
                DateTimeOffset.Parse("2023-11-01T00:00:00.0000000Z"),
                DateTimeOffset.Parse("2023-11-02T12:00:00.0000000Z"), 50));
            var result = await dataFactory.GetDataFactoryTriggers().CreateOrUpdateAsync(WaitUntil.Completed, triggerName, data);
        }

        [Test]
        [RecordedTest]
        public async Task Trigger_TriggerRun()
        {
            DataFactoryResource dataFactory = await TestSetUp();
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
