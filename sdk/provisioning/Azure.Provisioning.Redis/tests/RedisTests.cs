// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.KeyVaults;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;

namespace Azure.Provisioning.Redis.Tests
{
    public class RedisTests : ProvisioningTestBase
    {
        public RedisTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task RedisCacheResource()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var cache = new RedisCache(infrastructure);
            _ = new RedisFirewallRule(infrastructure, parent: cache);
            _ = infrastructure.AddKeyVault();
            _ = new KeyVaultSecret(infrastructure, name: "connectionString", connectionString: cache.GetConnectionString());

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ExistingRedisResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            var cache = RedisCache.FromExisting(infra, "'existingRedisCache'", rg);
            infra.AddResource(cache);
            infra.AddResource(RedisFirewallRule.FromExisting(infra, "'existingRedisFirewallRule'", cache));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
