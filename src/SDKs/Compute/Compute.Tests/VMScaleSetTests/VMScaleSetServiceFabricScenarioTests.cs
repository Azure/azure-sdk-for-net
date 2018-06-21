using Microsoft.Azure.Management.Compute;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetServiceFabricScenarioTests : VMScaleSetTestsBase
    {
        /// <summary>
        /// Covers manual UD walk operation. Or technically,
        /// ForceRecoveryServiceFabricPlatformUpdateDomainWalk
        /// </summary>
        [Fact(Skip = "ReRecord due to CR change")]
        public void TestVMScaleSetServiceFabric()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TestVMScaleSetServiceFabricImpl(context);
            }
        }

        private void TestVMScaleSetServiceFabricImpl(MockContext context)
        {
            /*
             * IMPORTANT: Since code to create an SF cluster is not there and needs to be added, it has not been done
             * for now. The workaround right now is to run the BVT in debug mode and pause before the following API
             * calls are made. This has been done to ensure tests work correctly. The SF-specific scaffolding will
             * be added in a future PR.
             */
            EnsureClientsInitialized(context);

            string rgName = "crptestrgr97ryo0ni";
            string vmssName = "crptesthtn39hve";

            var response = m_CrpClient.VirtualMachineScaleSets.ForceRecoveryServiceFabricPlatformUpdateDomainWalk(rgName, vmssName, 0);

#if NET46
            Assert.True((bool) response.WalkPerformed);
            Assert.Equal(1, response.NextPlatformUpdateDomain);
            response = m_CrpClient.VirtualMachineScaleSets.ForceRecoveryServiceFabricPlatformUpdateDomainWalk(rgName, vmssName, 1);
            Assert.True((bool) response.WalkPerformed);
            Assert.Equal(2, response.NextPlatformUpdateDomain);
            response = m_CrpClient.VirtualMachineScaleSets.ForceRecoveryServiceFabricPlatformUpdateDomainWalk(rgName, vmssName, 2);
            Assert.True((bool) response.WalkPerformed);
            Assert.Equal(3, response.NextPlatformUpdateDomain);
            response= m_CrpClient.VirtualMachineScaleSets.ForceRecoveryServiceFabricPlatformUpdateDomainWalk(rgName, vmssName, 3);
            Assert.True ((bool) response.WalkPerformed);
            Assert.Equal(4, response.NextPlatformUpdateDomain);
            response = m_CrpClient.VirtualMachineScaleSets.ForceRecoveryServiceFabricPlatformUpdateDomainWalk(rgName, vmssName, 4);
            Assert.True((bool) response.WalkPerformed);
            Assert.Equal(5, response.NextPlatformUpdateDomain);
            response = m_CrpClient.VirtualMachineScaleSets.ForceRecoveryServiceFabricPlatformUpdateDomainWalk(rgName, vmssName, 5);
            Assert.True((bool) response.WalkPerformed);
            Assert.Null(response.NextPlatformUpdateDomain);
#else
            Assert.True(response.WalkPerformed);
            Assert.Equal(1, response.NextPlatformUpdateDomain);
            response = m_CrpClient.VirtualMachineScaleSets.ForceRecoveryServiceFabricPlatformUpdateDomainWalk(rgName, vmssName, 1);
            Assert.True(response.WalkPerformed);
            Assert.Equal(2, response.NextPlatformUpdateDomain);
            response = m_CrpClient.VirtualMachineScaleSets.ForceRecoveryServiceFabricPlatformUpdateDomainWalk(rgName, vmssName, 2);
            Assert.True(response.WalkPerformed);
            Assert.Equal(3, response.NextPlatformUpdateDomain);
            response= m_CrpClient.VirtualMachineScaleSets.ForceRecoveryServiceFabricPlatformUpdateDomainWalk(rgName, vmssName, 3);
            Assert.True(response.WalkPerformed);
            Assert.Equal(4, response.NextPlatformUpdateDomain);
            response = m_CrpClient.VirtualMachineScaleSets.ForceRecoveryServiceFabricPlatformUpdateDomainWalk(rgName, vmssName, 4);
            Assert.True(response.WalkPerformed);
            Assert.Equal(5, response.NextPlatformUpdateDomain);
            response = m_CrpClient.VirtualMachineScaleSets.ForceRecoveryServiceFabricPlatformUpdateDomainWalk(rgName, vmssName, 5);
            Assert.True(response.WalkPerformed);
            Assert.Null(response.NextPlatformUpdateDomain);
#endif
        }
    }
}
