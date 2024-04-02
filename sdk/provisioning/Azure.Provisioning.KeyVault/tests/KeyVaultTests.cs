// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;

namespace Azure.Provisioning.KeyVaults.Tests
{
    public class KeyVaultTests : ProvisioningTestBase
    {
        public KeyVaultTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task KeyVaultSecretResource()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var vault = infrastructure.AddKeyVault();
            _ = new KeyVaultSecret(infrastructure, vault);

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task KeyVaultNetworkRuleSet()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var vault = infrastructure.AddKeyVault();
            vault.AssignProperty(data => data.Properties.NetworkRuleSet.DefaultAction, "'Allow'");
            vault.AssignProperty(data => data.Properties.NetworkRuleSet.Bypass, "'AzureServices'");

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingKeyVaultResource()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            var kv = KeyVault.FromExisting(infra, "'existingVault'", rg);
            infra.AddResource(kv);
            infra.AddResource(KeyVaultSecret.FromExisting(infra, "'existingSecret'", kv));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
