// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using System;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.tests.Tests
{
    public class VirtualNetworkTests
    {
        // CreateVirtualNetwork
        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate_CreateVirtualNetwork()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/CreateVirtualNetwork.json
            // this example is just showing the usage of "VirtualNetworks_Create" operation, for the dependent resources, they will have to be created separately.

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

            // get the collection of this VMwareVirtualNetworkResource
            VMwareVirtualNetworkCollection collection = resourceGroupResource.GetVMwareVirtualNetworks();

            // invoke the operation
            string virtualNetworkName = "VM-Network";
            VMwareVirtualNetworkData data = new VMwareVirtualNetworkData(new AzureLocation("East US"))
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    ExtendedLocationType = "CustomLocation",
                    Name = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/azcli-test-rg/providers/microsoft.extendedlocation/customlocations/azcli-test-cl",
                },
                InventoryItemId = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/network-563661",
            };
            ArmOperation<VMwareVirtualNetworkResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkName, data);
            VMwareVirtualNetworkResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VMwareVirtualNetworkData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // GetVirtualNetwork
        [TestCase]
        [RecordedTest]
        public async Task Get_GetVirtualNetwork()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/GetVirtualNetwork.json
            // this example is just showing the usage of "VirtualNetworks_Get" operation, for the dependent resources, they will have to be created separately.

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

            // get the collection of this VMwareVirtualNetworkResource
            VMwareVirtualNetworkCollection collection = resourceGroupResource.GetVMwareVirtualNetworks();

            // invoke the operation
            string virtualNetworkName = "VM-Network";
            VMwareVirtualNetworkResource result = await collection.GetAsync(virtualNetworkName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VMwareVirtualNetworkData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // GetVirtualNetwork
        [TestCase]
        [RecordedTest]
        public async Task Exists_GetVirtualNetwork()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/GetVirtualNetwork.json
            // this example is just showing the usage of "VirtualNetworks_Get" operation, for the dependent resources, they will have to be created separately.

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

            // get the collection of this VMwareVirtualNetworkResource
            VMwareVirtualNetworkCollection collection = resourceGroupResource.GetVMwareVirtualNetworks();

            // invoke the operation
            string virtualNetworkName = "VM-Network";
            bool result = await collection.ExistsAsync(virtualNetworkName);

            Console.WriteLine($"Succeeded: {result}");
        }

        // GetVirtualNetwork
        [TestCase]
        [RecordedTest]
        public async Task GetIfExists_GetVirtualNetwork()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/GetVirtualNetwork.json
            // this example is just showing the usage of "VirtualNetworks_Get" operation, for the dependent resources, they will have to be created separately.

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

            // get the collection of this VMwareVirtualNetworkResource
            VMwareVirtualNetworkCollection collection = resourceGroupResource.GetVMwareVirtualNetworks();

            // invoke the operation
            string virtualNetworkName = "VM-Network";
            NullableResponse<VMwareVirtualNetworkResource> response = await collection.GetIfExistsAsync(virtualNetworkName);
            VMwareVirtualNetworkResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine($"Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VMwareVirtualNetworkData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }

        // ListVirtualNetworksByResourceGroup
        [TestCase]
        [RecordedTest]
        public async Task GetAll_ListVirtualNetworksByResourceGroup()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/ListVirtualNetworksByResourceGroup.json
            // this example is just showing the usage of "VirtualNetworks_ListByResourceGroup" operation, for the dependent resources, they will have to be created separately.

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

            // get the collection of this VMwareVirtualNetworkResource
            VMwareVirtualNetworkCollection collection = resourceGroupResource.GetVMwareVirtualNetworks();

            // invoke the operation and iterate over the result
            await foreach (VMwareVirtualNetworkResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VMwareVirtualNetworkData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
