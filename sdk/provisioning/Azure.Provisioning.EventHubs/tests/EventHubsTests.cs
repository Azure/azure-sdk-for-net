// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;

namespace Azure.Provisioning.EventHubs.Tests
{
    public class EventHubsTests : ProvisioningTestBase
    {
        public EventHubsTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task EventHubs()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var account = new EventHubsNamespace(infrastructure);
            var hub = new EventHub(infrastructure, parent: account);
            var consumerGroup = new EventHubsConsumerGroup(infrastructure, parent: hub);
            account.AssignRole(RoleDefinition.EventHubsDataOwner, Guid.Empty);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingEventHubsResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            var eh = EventHubsNamespace.FromExisting(infra, "'existingEhNamespace'", rg);
            var hub = EventHub.FromExisting(infra, "'existingHub'", eh);
            infra.AddResource(hub);
            infra.AddResource(EventHubsConsumerGroup.FromExisting(infra, "'existingEhConsumerGroup'", hub));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
