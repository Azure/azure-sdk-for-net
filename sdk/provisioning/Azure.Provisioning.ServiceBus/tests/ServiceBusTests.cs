// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;

namespace Azure.Provisioning.ServiceBus.Tests
{
    public class ServiceBusTests : ProvisioningTestBase
    {
        public ServiceBusTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ServiceBuResources()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var account = new ServiceBusNamespace(infrastructure);
            _ = new ServiceBusQueue(infrastructure, parent: account);
            var topic = new ServiceBusTopic(infrastructure, parent: account);
            _ = new ServiceBusSubscription(infrastructure, parent: topic);
            account.AssignRole(RoleDefinition.ServiceBusDataOwner, Guid.Empty);
            account.AddOutput("endpoint", "'Endpoint=${{{0}}}'", data => data.ServiceBusEndpoint);
            account.AddOutput("expression", "uniqueString({0})", data => data.ServiceBusEndpoint);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingServiceBusResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            var sb = ServiceBusNamespace.FromExisting(infra, "'existingSbNamespace'", rg);
            infra.AddResource(ServiceBusQueue.FromExisting(infra, "'existingSbQueue'", sb));
            var topic = ServiceBusTopic.FromExisting(infra, "'existingSbTopic'", sb);
            infra.AddResource(topic);
            infra.AddResource(ServiceBusSubscription.FromExisting(infra, "'existingSbSubscription'", topic));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
