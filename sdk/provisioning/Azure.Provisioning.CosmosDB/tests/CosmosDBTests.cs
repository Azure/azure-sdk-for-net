// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.KeyVaults;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.Provisioning.CosmosDB.Tests
{
    public class CosmosDBTests : ProvisioningTestBase
    {
        public CosmosDBTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CosmosDBResources()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            infrastructure.AddParameter(new Parameter("keyVaultName"));
            var account = new CosmosDBAccount(
                infrastructure,
                accountLocations: new CosmosDBAccountLocation[]
                {
                    new CosmosDBAccountLocation
                    {
                        FailoverPriority = 0
                    }
                });
            account.AssignProperty(data => data.Locations[0].LocationName, "location");
            _ = new CosmosDBSqlDatabase(infrastructure, account);
            var kv = KeyVaults.KeyVault.FromExisting(infrastructure, "'existingVault'");
            _ = new KeyVaultSecret(infrastructure, "connectionString", account.GetConnectionString(), kv);

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(
                BinaryData.FromObjectAsJson(
                    new
                    {
                        keyVaultName = new { value = "vault" },
                    }),
                interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingCosmosDBResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            var cosmosDB = CosmosDBAccount.FromExisting(infra, "'cosmosDb'", rg);
            infra.AddResource(cosmosDB);
            infra.AddResource(CosmosDBSqlDatabase.FromExisting(infra, "'cosmosDb'", cosmosDB));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
