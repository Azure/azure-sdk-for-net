// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    public class Sample3_CreatingAVirtualNetwork
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateResourceGroupAsync()
        {
            #region Snippet:Creating_A_Virtual_Network_CreateResourceGroup
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

            string resourceGroupName = "myResourceGroup";
            ResourceGroupData resourceGroupData = new ResourceGroupData(AzureLocation.WestUS2);
            ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
            ResourceGroupResource resourceGroup = operation.Value;
            #endregion Snippet:Creating_A_Virtual_Network_CreateResourceGroup
        }
    }
}
