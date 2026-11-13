// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor.PipelineGroups.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.PipelineGroups.Tests
{
    public class PipelineGroupOperationsTests : MonitorManagementTestBase
    {
        public PipelineGroupOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        private async Task<PipelineGroupResource> CreatePipelineGroupAsync(ResourceGroupResource resourceGroup, string pipelineGroupName)
        {
            var extendedLocation = new ExtendedLocation()
            {
                ExtendedLocationType = "CustomLocation",
                Name = TestEnvironment.CustomLocationId
            };

            var receiver = new PipelineGroupReceiver(PipelineGroupReceiverType.Syslog, "syslog-receiver1")
            {
                Syslog = new PipelineGroupSyslogReceiver("0.0.0.0:6514")
            };

            var recordMap = new PipelineGroupRecordMap[]
            {
                new PipelineGroupRecordMap("body", "Body"),
                new PipelineGroupRecordMap("time_unix_nano", "TimeGenerated")
            };

            var amwslApiConfig = new AzureMonitorWorkspaceLogsApiConfig(
                dataCollectionEndpointUri: TestEnvironment.DataCollectionEndpointUri,
                stream: TestEnvironment.DataCollectionStream,
                dataCollectionRuleId: TestEnvironment.DataCollectionRule,
                schema: new PipelineGroupSchemaMap(recordMap)
            );

            var exporter = new PipelineGroupExporter(PipelineGroupExporterType.AzureMonitorWorkspaceLogs, "amw-exporter1")
            {
                AzureMonitorWorkspaceLogs = new AzureMonitorWorkspaceLogsExporter(amwslApiConfig)
            };

            var processor = new PipelineGroupProcessor(PipelineGroupProcessorType.Batch, "batch-processor1");

            var pipeline = new PipelineGroupPipeline(
                "logs-pipeline1",
                PipelineGroupPipelineType.Logs,
                new[] { receiver.Name },
                new[] { exporter.Name });

            var service = new PipelineGroupService(new[] { pipeline });

            var properties = new PipelineGroupProperties(
                new[] { receiver },
                new[] { processor },
                new[] { exporter },
                service);

            var data = new PipelineGroupData(AzureLocation.WestUS2)
            {
                ExtendedLocation = extendedLocation,
                Properties = properties,
            };

            var collection = resourceGroup.GetPipelineGroups();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, pipelineGroupName, data);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroup(DefaultSubscription, "pipelinegroup-rg", AzureLocation.EastUS);
            var pipelineGroupName = Recording.GenerateAssetName("testPipelineGroup-");

            var pipelineGroup = await CreatePipelineGroupAsync(resourceGroup, pipelineGroupName);

            Assert.That(pipelineGroup, Is.Not.Null);
            Assert.That(pipelineGroup.Data, Is.Not.Null);
            Assert.That(pipelineGroup.Data.Name, Is.EqualTo(pipelineGroupName));
            Assert.That(pipelineGroup.Data.Properties, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroup(DefaultSubscription, "pipelinegroup-rg", AzureLocation.EastUS);
            var pipelineGroupName = Recording.GenerateAssetName("testPipelineGroup-");

            var created = await CreatePipelineGroupAsync(resourceGroup, pipelineGroupName);
            PipelineGroupResource fetched = await created.GetAsync();

            Assert.That(fetched, Is.Not.Null);
            Assert.That(fetched.Data.Name, Is.EqualTo(created.Data.Name));
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var resourceGroup = await CreateResourceGroup(DefaultSubscription, "pipelinegroup-rg", AzureLocation.EastUS);
            var pipelineGroupName = Recording.GenerateAssetName("testPipelineGroup-");

            var pipelineGroup = await CreatePipelineGroupAsync(resourceGroup, pipelineGroupName);
            await pipelineGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
