// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.ManagedServiceIdentities;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;

namespace Azure.Provisioning.ManagedIdentities.Tests
{
    public class ManagedIdentitiesTests : ProvisioningTestBase
    {
        public ManagedIdentitiesTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task UserAssignedIdentities()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            _ = new UserAssignedIdentity(infrastructure);

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingUserAssignedIdentityResource()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            infra.AddResource(UserAssignedIdentity.FromExisting(infra, "'existingUserAssignedIdentity'", rg));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
