// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.OperationalInsights;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;

namespace Azure.Provisioning.ApplicationInsights.Tests
{
    public class AppInsightsTests : ProvisioningTestBase
    {
        public AppInsightsTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task AppInsights()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var workspace = new OperationalInsightsWorkspace(infrastructure);
            var output = workspace.AddOutput("workspaceId", data => data.Id);

            var appInsights = new ApplicationInsightsComponent(infrastructure);
            appInsights.AssignProperty(data => data.WorkspaceResourceId, new Parameter(output));

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingAppInsightsResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            infra.AddResource(ApplicationInsightsComponent.FromExisting(infra, "'existingAppInsights'", rg));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
