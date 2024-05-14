// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;
using Azure.ResourceManager.WebPubSub.Models;

namespace Azure.Provisioning.WebPubSub.Tests
{
    public class WebPubSubTests : ProvisioningTestBase
    {
        public WebPubSubTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task WebPubSub()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var wps = new WebPubSubService(infrastructure, sku: new BillingInfoSku("Standard_S1"));
            wps.AssignRole(RoleDefinition.WebPubSubServiceOwner, Guid.Empty);
            var properties = new WebPubSubHubProperties();
            properties.EventHandlers.Add(new WebPubSubEventHandler("tunnel:///eventhandler") { UserEventPattern = "*" });
            _ = new WebPubSubHub(infrastructure, properties, parent: wps);
            wps.AddOutput("hostName", data => data.HostName);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingWebPubSubResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();
            infra.AddResource(WebPubSubService.FromExisting(infra, "'existingWebPubSub'", rg));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
