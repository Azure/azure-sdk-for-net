// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;
using Azure.ResourceManager.Resources.Models;

namespace Azure.Provisioning.Resources.Tests
{
    public class ResourcesTests : ProvisioningTestBase
    {
        public ResourcesTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task DeploymentScriptResource()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var script = new DeploymentScript(infrastructure, new[] { new ScriptEnvironmentVariable("foo") }, "echo $foo");
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingDeploymentScriptResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            infra.AddResource(DeploymentScript.FromExisting(infra, "'existingDeploymentScript'", rg));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
