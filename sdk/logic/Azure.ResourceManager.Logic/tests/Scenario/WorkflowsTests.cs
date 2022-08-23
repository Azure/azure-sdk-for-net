// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        private IntegrationServiceEnvironmentCollection _integrationServiceEnvironmentCollection => _resourceGroup.GetIntegrationServiceEnvironments();

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
    }
}
