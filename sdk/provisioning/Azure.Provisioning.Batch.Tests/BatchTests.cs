using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;

namespace Azure.Provisioning.Batch.Tests
{
    public class BatchTests : ProvisioningTestBase
    {
        public BatchTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task BatchAccounts()
        {
            TestInfrastructure infrastructure =
                new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var account = new BatchAccount(infrastructure);
            var pool = new BatchPool(infrastructure, parent: account);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode true);
        }

        [RecordedTest]
        public async Task ExistingBatchResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            var account = BatchAccount.FromExisting(infra, "'existingAccount'", rg);
            var pool = BatchPool.FromExisting(infra, "'existingPool'", account);
            infra.AddResource(pool);

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
