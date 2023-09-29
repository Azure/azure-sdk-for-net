// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    public class Sample5_GenericResource
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public static async Task GetGenericResourceList()
        {
            #region Snippet:Get_GenericResource_List
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource sub = client.GetDefaultSubscription();
            AsyncPageable<GenericResource> networkAndVmWithTestInName = sub.GetGenericResourcesAsync(
                // Set filter to only return virtual network and virtual machine resource with 'test' in the name
                filter: "(resourceType eq 'Microsoft.Network/virtualNetworks' or resourceType eq 'Microsoft.Compute/virtualMachines') and substringof('test', name)",
                // Include 'createdTime' and 'changeTime' properties in the returned data
                expand: "createdTime,changedTime"
                );

            int count = 0;
            await foreach (var res in networkAndVmWithTestInName)
            {
                Console.WriteLine($"{res.Id.Name} in resource group {res.Id.ResourceGroupName} created at {res.Data.CreatedOn} and changed at {res.Data.ChangedOn}");
                count++;
            }
            Console.WriteLine($"{count} resources found");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public static async Task CreateGenericResource()
        {
            #region Snippet:Create_GenericResource
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            var subnetName = "samplesubnet";
            var addressSpaces = new Dictionary<string, object>()
            {
                { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
            };
            var subnet = new Dictionary<string, object>()
            {
                { "name", subnetName },
                { "properties", new Dictionary<string, object>()
                    {
                        { "addressPrefix", "10.0.1.0/24" }
                    }
                }
            };
            var subnets = new List<object>() { subnet };
            var data = new GenericResourceData(AzureLocation.EastUS)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                })
            };
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/{subscription_id}/resourceGroups/{resourcegroup_name}/providers/Microsoft.Network/virtualNetworks/{vnet_name}");

            var createResult = await client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, id, data);
            Console.WriteLine($"Resource {createResult.Value.Id.Name} in resource group {createResult.Value.Id.ResourceGroupName} created");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public static async Task UpdateGenericResource()
        {
            #region Snippet:Update_GenericResource
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            var subnetName = "samplesubnet";
            var addressSpaces = new Dictionary<string, object>()
            {
                { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
            };
            var subnet = new Dictionary<string, object>()
            {
                { "name", subnetName },
                { "properties", new Dictionary<string, object>()
                    {
                        { "addressPrefix", "10.0.1.0/24" }
                    }
                }
            };
            var subnets = new List<object>() { subnet };
            var data = new GenericResourceData(AzureLocation.EastUS)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                })
            };
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/{subscription_id}/resourceGroups/{resourcegroup_name}/providers/Microsoft.Network/virtualNetworks/{vnet_name}");

            var createResult = await client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, id, data);
            Console.WriteLine($"Resource {createResult.Value.Id.Name} in resource group {createResult.Value.Id.ResourceGroupName} updated");

            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public static async Task UpdateGenericResourceTags()
        {
            #region Snippet:Update_GenericResourc_Tags
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/{subscription_id}/resourceGroups/{resourcegroup_name}/providers/Microsoft.Network/virtualNetworks/{vnet_name}");
            GenericResource resource = client.GetGenericResources().Get(id).Value;

            GenericResourceData updateTag = new GenericResourceData(AzureLocation.EastUS);
            updateTag.Tags.Add("tag1", "sample-for-genericresource");
            ArmOperation<GenericResource> updateTagResult = await resource.UpdateAsync(WaitUntil.Completed, updateTag);

            Console.WriteLine($"Resource {updateTagResult.Value.Id.Name} in resource group {updateTagResult.Value.Id.ResourceGroupName} updated");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public static async Task GetGenericResource()
        {
            #region Snippet:Get_GenericResource
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/{subscription_id}/resourceGroups/{resourcegroup_name}/providers/Microsoft.Network/virtualNetworks/{vnet_name}");

            Response<GenericResource> getResultFromGenericResourceCollection = await client.GetGenericResources().GetAsync(id);
            Console.WriteLine($"Resource {getResultFromGenericResourceCollection.Value.Id.Name} in resource group {getResultFromGenericResourceCollection.Value.Id.ResourceGroupName} got");

            GenericResource resource = getResultFromGenericResourceCollection.Value;
            Response<GenericResource> getResultFromGenericResource = await resource.GetAsync();
            Console.WriteLine($"Resource {getResultFromGenericResource.Value.Id.Name} in resource group {getResultFromGenericResource.Value.Id.ResourceGroupName} got");

            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public static async Task IsGenericResourceExist()
        {
            #region Snippet:Is_GenericResource_Exist
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/{subscription_id}/resourceGroups/{resourcegroup_name}/providers/Microsoft.Network/virtualNetworks/{vnet_name}");

            bool existResult = await client.GetGenericResources().ExistsAsync(id);
            Console.WriteLine($"Resource exists: {existResult}");

            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public static async Task DeleteGenericResource()
        {
            #region Snippet:Delete_GenericResource
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/{subscription_id}/resourceGroups/{resourcegroup_name}/providers/Microsoft.Network/virtualNetworks/{vnet_name}");
            GenericResource resource = client.GetGenericResources().Get(id).Value;

            var deleteResult = await resource.DeleteAsync(WaitUntil.Completed);
            Console.WriteLine($"Resource deletion response status code: {deleteResult.WaitForCompletionResponse().Status}");

            #endregion
        }
    }
}
