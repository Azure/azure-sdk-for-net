// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using System;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests
{
    public class VirtualMachineTemplateTests
    {
        // CreateVirtualMachineTemplate
        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate_CreateVirtualMachineTemplate()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/CreateVirtualMachineTemplate.json
            // this example is just showing the usage of "VirtualMachineTemplates_Create" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "204898ee-cd13-4332-b9d4-55ca5c25496d";
            string resourceGroupName = "azcli-test-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this VMwareVmTemplateResource
            VMwareVmTemplateCollection collection = resourceGroupResource.GetVMwareVmTemplates();

            // invoke the operation
            string virtualMachineTemplateName = "azcli-test-linux-tmpl";
            VMwareVmTemplateData data = new VMwareVmTemplateData(new AzureLocation("East US"))
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    ExtendedLocationType = "CustomLocation",
                    Name = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/azcli-test-rg/providers/microsoft.extendedlocation/customlocations/azcli-test-cl",
                },
                InventoryItemId = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/vmtpl-vm-1184288",
            };
            ArmOperation<VMwareVmTemplateResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachineTemplateName, data);
            VMwareVmTemplateResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VMwareVmTemplateData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // GetVirtualMachineTemplate
        [TestCase]
        [RecordedTest]
        public async Task Get_GetVirtualMachineTemplate()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/GetVirtualMachineTemplate.json
            // this example is just showing the usage of "VirtualMachineTemplates_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "204898ee-cd13-4332-b9d4-55ca5c25496d";
            string resourceGroupName = "azcli-test-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this VMwareVmTemplateResource
            VMwareVmTemplateCollection collection = resourceGroupResource.GetVMwareVmTemplates();

            // invoke the operation
            string virtualMachineTemplateName = "azcli-test-linux-tmpl";
            VMwareVmTemplateResource result = await collection.GetAsync(virtualMachineTemplateName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VMwareVmTemplateData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // GetVirtualMachineTemplate
        [TestCase]
        [RecordedTest]
        public async Task Exists_GetVirtualMachineTemplate()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/GetVirtualMachineTemplate.json
            // this example is just showing the usage of "VirtualMachineTemplates_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "204898ee-cd13-4332-b9d4-55ca5c25496d";
            string resourceGroupName = "azcli-test-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this VMwareVmTemplateResource
            VMwareVmTemplateCollection collection = resourceGroupResource.GetVMwareVmTemplates();

            // invoke the operation
            string virtualMachineTemplateName = "azcli-test-linux-tmpl";
            bool result = await collection.ExistsAsync(virtualMachineTemplateName);

            Console.WriteLine($"Succeeded: {result}");
        }

        // GetVirtualMachineTemplate
        [TestCase]
        [RecordedTest]
        public async Task GetIfExists_GetVirtualMachineTemplate()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/GetVirtualMachineTemplate.json
            // this example is just showing the usage of "VirtualMachineTemplates_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "204898ee-cd13-4332-b9d4-55ca5c25496d";
            string resourceGroupName = "azcli-test-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this VMwareVmTemplateResource
            VMwareVmTemplateCollection collection = resourceGroupResource.GetVMwareVmTemplates();

            // invoke the operation
            string virtualMachineTemplateName = "azcli-test-linux-tmpl";
            NullableResponse<VMwareVmTemplateResource> response = await collection.GetIfExistsAsync(virtualMachineTemplateName);
            VMwareVmTemplateResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine($"Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VMwareVmTemplateData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }

        // ListVirtualMachineTemplatesByResourceGroup
        [TestCase]
        [RecordedTest]
        public async Task GetAll_ListVirtualMachineTemplatesByResourceGroup()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/ListVirtualMachineTemplatesByResourceGroup.json
            // this example is just showing the usage of "VirtualMachineTemplates_ListByResourceGroup" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "204898ee-cd13-4332-b9d4-55ca5c25496d";
            string resourceGroupName = "azcli-test-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this VMwareVmTemplateResource
            VMwareVmTemplateCollection collection = resourceGroupResource.GetVMwareVmTemplates();

            // invoke the operation and iterate over the result
            await foreach (VMwareVmTemplateResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VMwareVmTemplateData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
