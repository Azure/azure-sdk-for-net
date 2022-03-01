// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests.Fixtures
{
    using System.Collections.Generic;
    using System.Linq;
    using IntegrationTestUtilities;
    using Microsoft.Azure.Batch;
    using Xunit;

    public class IaasLinuxPoolFixture : PoolFixture
    {
        public IaasLinuxPoolFixture() : base(TestUtilities.GetMyName() + "-pooltest-linux")
        {
            Pool = CreatePool();
        }

        public static ImageInformation GetUbuntuImageDetails(BatchClient client)
        {
            List<ImageInformation> imageInformation = client.PoolOperations.ListSupportedImages().ToList();

            static bool ubuntuImageScanner(ImageInformation imageInfo) =>
                imageInfo.ImageReference.Publisher == "canonical" &&
                imageInfo.ImageReference.Offer == "ubuntuserver" &&
                imageInfo.ImageReference.Sku.Contains("18.04");

            ImageInformation ubuntuImage = imageInformation.First(ubuntuImageScanner);

            return ubuntuImage;
        }

        protected CloudPool CreatePool()
        {
            CloudPool currentPool = FindPoolIfExists();

            // gotta create a new pool
            if (currentPool == null)
            {
                var ubuntuImageDetails = GetUbuntuImageDetails(client);

                VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                    ubuntuImageDetails.ImageReference,
                    nodeAgentSkuId: ubuntuImageDetails.NodeAgentSkuId);

                currentPool = client.PoolOperations.CreatePool(
                    poolId: PoolId,
                    virtualMachineSize: VMSize,
                    virtualMachineConfiguration: virtualMachineConfiguration,
                    targetDedicatedComputeNodes: 1);

                currentPool.Commit();
            }

            return WaitForPoolAllocation(client, PoolId);
        }
    }

    [CollectionDefinition("SharedLinuxPoolCollection")]
    public class LinuxSharedPoolCollection : ICollectionFixture<IaasLinuxPoolFixture>
    {

    }
}
