// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.ResourceManager;
using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;

namespace Azure.Provisioning.Tests
{
    [AsyncOnly]
    public class ProvisioningTests : ProvisioningTestBase
    {
        public ProvisioningTests(bool async) : base(async)
        {
        }

        [RecordedTest]
        public async Task ResourceGroupOnly()
        {
            TestInfrastructure infrastructure = new TestInfrastructure();
            var resourceGroup = infrastructure.AddResourceGroup();
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task CanAddCustomLocationParameterInInteractiveMode()
        {
            var infra = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var rg = infra.AddResourceGroup();
            rg.AssignProperty(d => d.Location, new Parameter("myLocationParam"));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                new
                {
                    myLocationParam = new { value = "eastus" },
                }),
                interactiveMode: true);
        }

        [RecordedTest]
        public void MultipleSubscriptions()
        {
            // ensure deterministic subscription names and directories
            var random = new TestRandom(RecordedTestMode.Playback, 1);
            var infra = new TestSubscriptionInfrastructure();
            var sub1 = new Subscription(infra, random.NewGuid());
            var sub2 = new Subscription(infra, random.NewGuid());
            _ = new ResourceGroup(infra, parent: sub1);
            _ = new ResourceGroup(infra, parent: sub2);
            infra.Build(GetOutputPath());

            // Multiple subscriptions are not fully supported yet. https://github.com/Azure/azure-sdk-for-net/issues/42146
            // await ValidateBicepAsync();
        }
    }
}
