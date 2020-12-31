// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VMScaleSetServiceFabricScenarioTests : VMScaleSetTestsBase
    {
        public VMScaleSetServiceFabricScenarioTests(bool isAsync)
        : base(isAsync)
        {
        }
        /// <summary>
        /// Covers manual UD walk operation. Or technically,
        /// ForceRecoveryServiceFabricPlatformUpdateDomainWalk
        /// </summary>
        [Test]
        [Ignore("skip in track1")]
        //[Test(Skip = "ReRecord due to CR change")]
        public async Task TestVMScaleSetServiceFabric()
        {
            EnsureClientsInitialized(DefaultLocation);
            await TestVMScaleSetServiceFabricImpl();
        }

        private async Task TestVMScaleSetServiceFabricImpl()
        {
            /*
             * IMPORTANT: Since code to create an SF cluster is not there and needs to be added, it has not been done
             * for now. The workaround right now is to run the BVT in debug mode and pause before the following API
             * calls are made. This has been done to ensure tests work correctly. The SF-specific scaffolding will
             * be added in a future PR.
             */

            string rgName = "crptestrgr97ryo0ni";
            string vmssName = "crptesthtn39hve";

            var response = (await VirtualMachineScaleSetsOperations.ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(rgName, vmssName, 0)).Value;

            Assert.True(response.WalkPerformed);
            Assert.AreEqual(1, response.NextPlatformUpdateDomain);
            response = (await VirtualMachineScaleSetsOperations.ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(rgName, vmssName, 1)).Value;
            Assert.True(response.WalkPerformed);
            Assert.AreEqual(2, response.NextPlatformUpdateDomain);
            response = (await VirtualMachineScaleSetsOperations.ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(rgName, vmssName, 2)).Value;
            Assert.True(response.WalkPerformed);
            Assert.AreEqual(3, response.NextPlatformUpdateDomain);
            response = (await VirtualMachineScaleSetsOperations.ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(rgName, vmssName, 3)).Value;
            Assert.True(response.WalkPerformed);
            Assert.AreEqual(4, response.NextPlatformUpdateDomain);
            response = (await VirtualMachineScaleSetsOperations.ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(rgName, vmssName, 4)).Value;
            Assert.True(response.WalkPerformed);
            Assert.AreEqual(5, response.NextPlatformUpdateDomain);
            response = (await VirtualMachineScaleSetsOperations.ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(rgName, vmssName, 5)).Value;
            Assert.True(response.WalkPerformed);
            Assert.Null(response.NextPlatformUpdateDomain);
        }
    }
}
