using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    /// <summary>
    /// Disk encryption tests on VMSS
    /// </summary>
    /// <remarks>
    /// From API perspective, we need to verify DiskInstanceView for encryption settings per VM instance.
    /// Hence these tests are written under VM instance tests. There are no API changes at VMScaleSet level
    /// to support disk encryption on VMScaleSet
    /// </remarks>
    public class VMScaleSetVMDiskEncryptionTests : VMScaleSetVMTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create VMScaleSet with extension
        /// Get VMScaleSet VM instance view
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetVMDiskEncryptionOperation")]
        public void TestVMScaleSetVMDiskEncryptionOperation()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TestDiskEncryptionOnScaleSetVMInternal(context, hasManagedDisks: true, useVmssExtension: true);
            }
        }

        private void TestDiskEncryptionOnScaleSetVMInternal(MockContext context, bool hasManagedDisks = true, bool useVmssExtension = true)
        {
            EnsureClientsInitialized(context);

            // Get platform image for VMScaleSet create
            ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rgName = TestUtilities.GenerateName(TestPrefix);
            string vmssName = TestUtilities.GenerateName("vmss");
            string storageAccountName = TestUtilities.GenerateName(TestPrefix);
            var dnsname = TestUtilities.GenerateName("dnsname");

            // Create ADE extension to enable disk encryption
            VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
            {
                Extensions = new List<VirtualMachineScaleSetExtension>()
                {
                    GetAzureDiskEncryptionExtension(),
                }
            };

            bool testSucceeded = false;
            try
            {
                StorageAccount storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                var vnetResponse = CreateVNETWithSubnets(rgName, 2);
                var vmssSubnet = vnetResponse.Subnets[1];

                var publicipConfiguration = new VirtualMachineScaleSetPublicIPAddressConfiguration();
                publicipConfiguration.Name = "pip1";
                publicipConfiguration.IdleTimeoutInMinutes = 10;
                publicipConfiguration.DnsSettings = new VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings();
                publicipConfiguration.DnsSettings.DomainNameLabel = dnsname;

                VirtualMachineScaleSet inputVMScaleSet;
                VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                    rgName,
                    vmssName,
                    storageAccountOutput,
                    imageRef,
                    out inputVMScaleSet,
                    useVmssExtension ? extensionProfile : null,
                    (vmss) =>
                    {
                        vmss.Sku.Name = "Standard_A3";
                        vmss.Sku.Tier = "Standard";
                        vmss.VirtualMachineProfile.StorageProfile.OsDisk = new VirtualMachineScaleSetOSDisk()
                        {
                            CreateOption = DiskCreateOptionTypes.FromImage,
                        };
                        vmss.VirtualMachineProfile.NetworkProfile
                                    .NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration = publicipConfiguration;
                    },
                    createWithManagedDisks: hasManagedDisks,
                    createWithPublicIpAddress: false,
                    subnet: vmssSubnet);

                VirtualMachineScaleSetVMInstanceView vmInstanceViewResponse =
                    m_CrpClient.VirtualMachineScaleSetVMs.GetInstanceView(rgName, vmScaleSet.Name, "0");
                Assert.True(vmInstanceViewResponse != null, "VMScaleSetVM not returned.");

                ValidateEncryptionSettingsInVMScaleSetVMInstanceView(vmInstanceViewResponse, hasManagedDisks);

                m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
                testSucceeded = true;
            }
            finally
            {
                //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                m_ResourcesClient.ResourceGroups.Delete(rgName);
            }

            Assert.True(testSucceeded);
        }
    }
}
