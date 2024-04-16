// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;
using Azure.ResourceManager.CognitiveServices.Models;

namespace Azure.Provisioning.CognitiveServices.Tests
{
    public class CognitiveServicesTests : ProvisioningTestBase
    {
        public CognitiveServicesTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public void CognitiveServices()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var account = new CognitiveServicesAccount(infrastructure, location: AzureLocation.EastUS);
            account.AssignProperty(data => data.Properties.PublicNetworkAccess, new Parameter("publicNetworkAccess", defaultValue: "Enabled"));
            account.AddOutput("endpoint", "'Endpoint=${{{0}}}'", data => data.Properties.Endpoint);
            account.AddOutput("expression", "uniqueString({0})", data => data.Properties.Endpoint);
            _ = new CognitiveServicesAccountDeployment(
                infrastructure,
                new CognitiveServicesAccountDeploymentModel
                {
                    Name = "text-embedding-3-large",
                    Format = "OpenAI",
                    Version = "1"
                },
                account);

            infrastructure.Build(GetOutputPath());

            // couldn't fine a deployable combination of sku and model using test subscription
            // await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingCognitiveServicesResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            var cognitiveServicesAccount = CognitiveServicesAccount.FromExisting(infra, "'cognitiveServices'", rg);
            infra.AddResource(cognitiveServicesAccount);
            infra.AddResource(CognitiveServicesAccountDeployment.FromExisting(infra, "'cognitiveServicesDeployment'", cognitiveServicesAccount));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
