// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;

namespace Azure.Provisioning.OperationalInsights.Tests
{
    public class OperationalInsightsTests : ProvisioningTestBase
    {
        public OperationalInsightsTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task OperationalInsights()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var workspace = new OperationalInsightsWorkspace(infrastructure);
            workspace.AddOutput("workspaceId", data => data.Id);

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingOperationalInsightsResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            infra.AddResource(OperationalInsightsWorkspace.FromExisting(infra, "'existingWorkspace'", rg));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
