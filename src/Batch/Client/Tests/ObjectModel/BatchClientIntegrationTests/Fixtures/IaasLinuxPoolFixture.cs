// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchClientIntegrationTests.Fixtures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IntegrationTestUtilities;
    using Microsoft.Azure.Batch;
    using Xunit;

    public struct IaasPoolProvisioningDetails
    {
        public IaasPoolProvisioningDetails(ImageReference imageReference, NodeAgentSku nodeAgentSku)
        {
            this.ImageReference = imageReference;
            this.NodeAgentSku = nodeAgentSku;
        }

        public ImageReference ImageReference { get; }
        public NodeAgentSku NodeAgentSku { get; }
    }

    public class IaasLinuxPoolFixture : PoolFixture
    {
        public IaasLinuxPoolFixture() : base(TestUtilities.GetMyName() + "-pooltest-linux")
        {
            this.Pool = this.CreatePool();
        }

        public static IaasPoolProvisioningDetails GetUbuntuImageDetails(BatchClient client)
        {
            List<NodeAgentSku> nodeAgentSkus = client.PoolOperations.ListNodeAgentSkus().ToList();

            Func<ImageReference, bool> ubuntuImageScanner = imageRef =>
                imageRef.Publisher == "Canonical" &&
                imageRef.Offer == "UbuntuServer" &&
                imageRef.Sku.Contains("14.04");

            NodeAgentSku ubuntuSku =
                nodeAgentSkus.First(sku => sku.VerifiedImageReferences.FirstOrDefault(ubuntuImageScanner) != null);

            ImageReference imageReference = ubuntuSku.VerifiedImageReferences.First(ubuntuImageScanner);

            return new IaasPoolProvisioningDetails(imageReference, ubuntuSku);
        }

        protected CloudPool CreatePool()
        {
            CloudPool currentPool = this.FindPoolIfExists();

            // gotta create a new pool
            if (currentPool == null)
            {
                var ubuntuImageDetails = GetUbuntuImageDetails(this.client);

                VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                    ubuntuImageDetails.ImageReference,
                    nodeAgentSkuId: ubuntuImageDetails.NodeAgentSku.Id);

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
