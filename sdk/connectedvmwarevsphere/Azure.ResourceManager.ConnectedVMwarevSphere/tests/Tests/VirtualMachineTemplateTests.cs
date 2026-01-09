// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests
{
    public class VirtualMachineTemplateTests : ConnectedVMwareTestBase
    {
        public VirtualMachineTemplateTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task VirtualMachineTemplate_Create_Get_Exists_GetIfExists_List_Delete()
        {
            VMwareVmTemplateCollection collection = DefaultResourceGroup.GetVMwareVmTemplates();

            // Create
            string vmTemplateName = Recording.GenerateAssetName("vmtemplate");
            VMwareVmTemplateData data = new VMwareVmTemplateData(DefaultLocation)
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    ExtendedLocationType = "CustomLocation",
                    Name = $"/subscriptions/{DefaultSubscriptionId}/resourcegroups/{DefaultResourceGroupName}/providers/microsoft.extendedlocation/customlocations/azcli-test-cl",
                },
                InventoryItemId = $"/subscriptions/{DefaultSubscriptionId}/resourceGroups/{DefaultResourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/vmtpl-vm-1184288",
            };
            ArmOperation<VMwareVmTemplateResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmTemplateName, data);
            VMwareVmTemplateResource vmTemplate = lro.Value;
            Assert.That(vmTemplate, Is.Not.Null);
            VMwareVmTemplateData resourceData = vmTemplate.Data;
            Assert.That(vmTemplateName, Is.EqualTo(resourceData.Name));

            // Get
            VMwareVmTemplateResource result = await collection.GetAsync(vmTemplateName);
            Assert.That(result, Is.Not.Null);

            // Check exists
            bool isExist = await collection.ExistsAsync(vmTemplateName);
            Assert.That(isExist, Is.True);

            // Get if exists
            NullableResponse<VMwareVmTemplateResource> response = await collection.GetIfExistsAsync(vmTemplateName);
            result = response.HasValue ? response.Value : null;
            Assert.That(result, Is.Not.Null);

            // List
            isExist = false;
            await foreach (VMwareVmTemplateResource item in collection.GetAllAsync())
            {
                if (item.Data.Name == vmTemplateName)
                    isExist = true;
            }
            Assert.That(isExist, Is.True);

            // Delete
            await vmTemplate.DeleteAsync(WaitUntil.Completed);
        }
    }
}
