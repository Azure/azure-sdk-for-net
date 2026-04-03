// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.NetworkCloud.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NetworkCloud.Samples
{
    public partial class Sample_NetworkCloudAccessBridgeResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetAccessBridge()
        {
            // this example is just showing the usage of "AccessBridges_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this NetworkCloudAccessBridgeResource created on azure
            // for more information of creating NetworkCloudAccessBridgeResource, please refer to the document of NetworkCloudAccessBridgeResource
            string subscriptionId = "123e4567-e89b-12d3-a456-426655440000";
            string resourceGroupName = "resourceGroupName";
            NetworkCloudAccessBridgeAllowedName accessBridgeName = NetworkCloudAccessBridgeAllowedName.Bastion;
            ResourceIdentifier networkCloudAccessBridgeResourceId = NetworkCloudAccessBridgeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accessBridgeName);
            NetworkCloudAccessBridgeResource networkCloudAccessBridge = client.GetNetworkCloudAccessBridgeResource(networkCloudAccessBridgeResourceId);

            // invoke the operation
            NetworkCloudAccessBridgeResource result = await networkCloudAccessBridge.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            NetworkCloudAccessBridgeData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_DeleteAccessBridge()
        {
            // this example is just showing the usage of "AccessBridges_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this NetworkCloudAccessBridgeResource created on azure
            // for more information of creating NetworkCloudAccessBridgeResource, please refer to the document of NetworkCloudAccessBridgeResource
            string subscriptionId = "123e4567-e89b-12d3-a456-426655440000";
            string resourceGroupName = "resourceGroupName";
            NetworkCloudAccessBridgeAllowedName accessBridgeName = NetworkCloudAccessBridgeAllowedName.Bastion;
            ResourceIdentifier networkCloudAccessBridgeResourceId = NetworkCloudAccessBridgeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accessBridgeName);
            NetworkCloudAccessBridgeResource networkCloudAccessBridge = client.GetNetworkCloudAccessBridgeResource(networkCloudAccessBridgeResourceId);

            // invoke the operation
            ArmOperation<NetworkCloudOperationStatusResult> lro = await networkCloudAccessBridge.DeleteAsync(WaitUntil.Completed, default);
            NetworkCloudOperationStatusResult result = lro.Value;

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_PatchAccessBridge()
        {
            // this example is just showing the usage of "AccessBridges_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this NetworkCloudAccessBridgeResource created on azure
            // for more information of creating NetworkCloudAccessBridgeResource, please refer to the document of NetworkCloudAccessBridgeResource
            string subscriptionId = "123e4567-e89b-12d3-a456-426655440000";
            string resourceGroupName = "resourceGroupName";
            NetworkCloudAccessBridgeAllowedName accessBridgeName = NetworkCloudAccessBridgeAllowedName.Bastion;
            ResourceIdentifier networkCloudAccessBridgeResourceId = NetworkCloudAccessBridgeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accessBridgeName);
            NetworkCloudAccessBridgeResource networkCloudAccessBridge = client.GetNetworkCloudAccessBridgeResource(networkCloudAccessBridgeResourceId);

            // invoke the operation
            NetworkCloudAccessBridgePatch patch = new NetworkCloudAccessBridgePatch
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2"
                },
            };
            ArmOperation<NetworkCloudAccessBridgeResource> lro = await networkCloudAccessBridge.UpdateAsync(WaitUntil.Completed, patch, default);
            NetworkCloudAccessBridgeResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            NetworkCloudAccessBridgeData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
