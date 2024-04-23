// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;
using Azure.ResourceManager.SignalR.Models;

namespace Azure.Provisioning.SignalR.Tests
{
    public class SignalRTests : ProvisioningTestBase
    {
        public SignalRTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task SignalRResources()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var signalR = new SignalRService(infrastructure, sku: new SignalRResourceSku("Standard_S1"), serviceMode: "Serverless");
            signalR.AssignRole(RoleDefinition.SignalRAppServer, Guid.Empty);

            signalR.AddOutput("hostName", data => data.HostName);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingSignalRResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();
            infra.AddResource(SignalRService.FromExisting(infra, "'existingSignalR'", rg));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
