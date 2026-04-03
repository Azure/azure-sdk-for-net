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
    public partial class Sample_NetworkCloudKubernetesVersionResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetKubernetesVersion()
        {
            // this example is just showing the usage of "KubernetesVersions_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this NetworkCloudKubernetesVersionResource created on azure
            // for more information of creating NetworkCloudKubernetesVersionResource, please refer to the document of NetworkCloudKubernetesVersionResource
            string subscriptionId = "123e4567-e89b-12d3-a456-426655440000";
            string resourceGroupName = "resourceGroupName";
            string kubernetesVersionName = "kubernetesVersionName";
            ResourceIdentifier networkCloudKubernetesVersionResourceId = NetworkCloudKubernetesVersionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, kubernetesVersionName);
            NetworkCloudKubernetesVersionResource networkCloudKubernetesVersion = client.GetNetworkCloudKubernetesVersionResource(networkCloudKubernetesVersionResourceId);

            // invoke the operation
            NetworkCloudKubernetesVersionResource result = await networkCloudKubernetesVersion.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            NetworkCloudKubernetesVersionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_DeleteKubernetesVersion()
        {
            // this example is just showing the usage of "KubernetesVersions_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this NetworkCloudKubernetesVersionResource created on azure
            // for more information of creating NetworkCloudKubernetesVersionResource, please refer to the document of NetworkCloudKubernetesVersionResource
            string subscriptionId = "123e4567-e89b-12d3-a456-426655440000";
            string resourceGroupName = "resourceGroupName";
            string kubernetesVersionName = "kubernetesVersionName";
            ResourceIdentifier networkCloudKubernetesVersionResourceId = NetworkCloudKubernetesVersionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, kubernetesVersionName);
            NetworkCloudKubernetesVersionResource networkCloudKubernetesVersion = client.GetNetworkCloudKubernetesVersionResource(networkCloudKubernetesVersionResourceId);

            // invoke the operation
            ArmOperation<NetworkCloudOperationStatusResult> lro = await networkCloudKubernetesVersion.DeleteAsync(WaitUntil.Completed, default);
            NetworkCloudOperationStatusResult result = lro.Value;

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_PatchKubernetesVersion()
        {
            // this example is just showing the usage of "KubernetesVersions_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this NetworkCloudKubernetesVersionResource created on azure
            // for more information of creating NetworkCloudKubernetesVersionResource, please refer to the document of NetworkCloudKubernetesVersionResource
            string subscriptionId = "123e4567-e89b-12d3-a456-426655440000";
            string resourceGroupName = "resourceGroupName";
            string kubernetesVersionName = "kubernetesVersionName";
            ResourceIdentifier networkCloudKubernetesVersionResourceId = NetworkCloudKubernetesVersionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, kubernetesVersionName);
            NetworkCloudKubernetesVersionResource networkCloudKubernetesVersion = client.GetNetworkCloudKubernetesVersionResource(networkCloudKubernetesVersionResourceId);

            // invoke the operation
            NetworkCloudKubernetesVersionPatch patch = new NetworkCloudKubernetesVersionPatch
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2"
                },
            };
            ArmOperation<NetworkCloudKubernetesVersionResource> lro = await networkCloudKubernetesVersion.UpdateAsync(WaitUntil.Completed, patch, default);
            NetworkCloudKubernetesVersionResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            NetworkCloudKubernetesVersionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
