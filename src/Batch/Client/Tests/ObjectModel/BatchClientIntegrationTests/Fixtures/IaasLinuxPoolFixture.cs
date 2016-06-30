namespace BatchClientIntegrationTests.Fixtures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IntegrationTestUtilities;
    using Microsoft.Azure.Batch;
    using Xunit;

    public class IaasLinuxPoolFixture : PoolFixture
    {
        public IaasLinuxPoolFixture() : base(TestUtilities.GetMyName() + "-pooltest-linux")
        {
            this.Pool = this.CreatePool();
        }

        protected CloudPool CreatePool()
        {
            CloudPool currentPool = this.FindPoolIfExists();

            // gotta create a new pool
            if (currentPool == null)
            {
                List<NodeAgentSku> nodeAgentSkus = this.client.PoolOperations.ListNodeAgentSkus().ToList();

                Func<ImageReference, bool> ubuntuImageScanner = imageRef => 
                    imageRef.Publisher == "Canonical" && 
                    imageRef.Offer == "UbuntuServer" && 
                    imageRef.Sku.Contains("14.04");

                NodeAgentSku ubuntuSku =
                    nodeAgentSkus.First(sku => sku.VerifiedImageReferences.FirstOrDefault(ubuntuImageScanner) != null);

                ImageReference imageReference = ubuntuSku.VerifiedImageReferences.First(ubuntuImageScanner);

                VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                    imageReference: imageReference,
                    nodeAgentSkuId: ubuntuSku.Id);

                currentPool = this.client.PoolOperations.CreatePool(
                    poolId: this.PoolId,
                    virtualMachineSize: VMSize,
                    virtualMachineConfiguration: virtualMachineConfiguration,
                    targetDedicated: 1);

                currentPool.Commit();
            }

            return WaitForPoolAllocation(this.client, this.PoolId);
        }
    }

    [CollectionDefinition("SharedLinuxPoolCollection")]
    public class LinuxSharedPoolCollection : ICollectionFixture<IaasLinuxPoolFixture>
    {

    }
}
