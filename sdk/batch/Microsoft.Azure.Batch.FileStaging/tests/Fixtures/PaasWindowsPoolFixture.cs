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

namespace Batch.FileStaging.Tests.Fixtures
{
    using System.Collections.Generic;
    using System.Linq;
    using IntegrationTestUtilities;
    using Microsoft.Azure.Batch;
    using Xunit;

    public class PaasWindowsPoolFixture : PoolFixture
    {
        public PaasWindowsPoolFixture()
            : base(TestUtilities.GetMyName() + "-pooltest")
        {
            this.Pool = this.CreatePool();
        }

        private static ImageInformation GetWindowsImageDetails(BatchClient client)
        {
            List<ImageInformation> imageInformation = client.PoolOperations.ListSupportedImages().ToList();

            ImageInformation windowsImage = imageInformation.First(imageInfo =>
                imageInfo.ImageReference.Publisher == "microsoftwindowsserver" &&
                imageInfo.ImageReference.Offer.Contains("windowsserver") &&
                imageInfo.ImageReference.Sku.Contains("2022-datacenter"));

            return windowsImage;
        }

        protected CloudPool CreatePool()
        {
            CloudPool currentPool = this.FindPoolIfExists();

            if (currentPool == null)
            {
                // gotta create a new pool
                var windowsImageDetails = GetWindowsImageDetails(this.client);

                VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                    windowsImageDetails.ImageReference,
                    nodeAgentSkuId: windowsImageDetails.NodeAgentSkuId);

                currentPool = this.client.PoolOperations.CreatePool(
                    this.PoolId,
                    VMSize,
                    virtualMachineConfiguration,
                    targetDedicatedComputeNodes: 1);

                StartTask st = new StartTask("cmd /c hostname");

                // used for tests of StartTask(info)
                st.EnvironmentSettings = new List<EnvironmentSetting>
                    {
                        new EnvironmentSetting("key", "value")
                    };
                currentPool.StartTask = st;

                currentPool.Commit();
            }

            return WaitForPoolAllocation(this.client, this.PoolId);
        }
    }

    /// <summary>
    /// This class is used by XUnit
    /// </summary>
    [CollectionDefinition("SharedPoolCollection")]
    public class SharedPoolCollection : ICollectionFixture<PaasWindowsPoolFixture>
    {

    }
}
