// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Logic.Tests
{
    internal class WorkflowsTests : LogicManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;

        private LogicWorkflowCollection _workflowCollection => _resourceGroup.GetLogicWorkflows();

        public WorkflowsTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            _resourceGroupIdentifier = rgLro.Value.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            string workflowName = SessionRecording.GenerateAssetName("workflow");
            byte[] definition = File.ReadAllBytes(@"..\..\..\..\..\sdk\logic\Azure.ResourceManager.Logic\tests\TestData\WorkflowDefinition.json");
            LogicWorkflowData data = new LogicWorkflowData(_resourceGroup.Data.Location)
            {
                Definition = new BinaryData(definition),
            };
            var workflow = await _workflowCollection.CreateOrUpdateAsync(WaitUntil.Completed,workflowName,data);
        }
    }
}
