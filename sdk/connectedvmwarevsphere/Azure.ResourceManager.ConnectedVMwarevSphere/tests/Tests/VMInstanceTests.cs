// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests
{
    public partial class Test_VirtualMachineInstanceResourceTests : ConnectedVMwareTestBase
    {
        public Test_VirtualMachineInstanceResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task VMInstance_Create_Update_Start_Stop_Delete()
        {
            // Create
            string resourceUri = $"/subscriptions/{DefaultSubscriptionId}/resourceGroups/{DefaultResourceGroupName}/providers/Microsoft.HybridCompute/machines/test-machine-dotnet_sdk2";
            ResourceIdentifier virtualMachineInstanceResourceId = VMwareVmInstanceResource.CreateResourceIdentifier(resourceUri);
            VMwareVmInstanceResource vMwareVmInstance = Client.GetVMwareVmInstanceResource(virtualMachineInstanceResourceId);

            // invoke the operation
            VMwareVmInstanceData data = new VMwareVmInstanceData()
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    Name = $"/subscriptions/{DefaultSubscriptionId}/resourcegroups/{DefaultResourceGroupName}/providers/microsoft.extendedlocation/customlocations/azcli-test-cl",
                    ExtendedLocationType = "CustomLocation",
                },
                InfrastructureProfile = new VCenterInfrastructureProfile()
                {
                    InventoryItemId= $"/subscriptions/{DefaultSubscriptionId}/resourceGroups/{DefaultResourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/vm-1532417",
                },
            };
            ArmOperation<VMwareVmInstanceResource> lro = await vMwareVmInstance.CreateOrUpdateAsync(WaitUntil.Completed, data);
            VMwareVmInstanceResource vmInstance = lro.Value;
            Assert.IsNotNull(vmInstance);

            // Update
            VMwareVmInstancePatch patch = new VMwareVmInstancePatch()
            {
                HardwareProfile = new VmInstanceHardwareProfile()
                {
                    MemorySizeMB = 4196,
                    NumCpus = 4,
                },
            };
            lro = await vMwareVmInstance.UpdateAsync(WaitUntil.Completed, patch);
            VMwareVmInstanceResource result = lro.Value;
            Assert.IsNotNull(result);
            VMwareVmInstanceData resourceData = result.Data;
            Assert.AreEqual(resourceData.HardwareProfile.MemorySizeMB, patch.HardwareProfile.MemorySizeMB);
            Assert.AreEqual(resourceData.HardwareProfile.NumCpus, patch.HardwareProfile.NumCpus);

            // Start
            await vmInstance.StartAsync(WaitUntil.Completed);

            // Stop
            StopVirtualMachineContent content = new StopVirtualMachineContent()
            {
                SkipShutdown = true,
            };
            await vmInstance.StopAsync(WaitUntil.Completed, content);

            // Delete
            await vmInstance.DeleteAsync(WaitUntil.Completed, false, false);
        }
    }
}
