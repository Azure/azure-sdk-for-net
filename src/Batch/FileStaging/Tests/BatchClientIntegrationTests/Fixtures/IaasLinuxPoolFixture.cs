// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace BatchClientIntegrationTests.Fixtures
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
