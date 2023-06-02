// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Dns.Tests.Samples
{
    public class Readme
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ClientAuth()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void DefaultSubscription()
        {
            #region Snippet:Readme_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = armClient.GetDefaultSubscription();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateResourceGroup()
        {
            #region Snippet:Readme_GetResourceGroupCollection
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = lro.Value;
            #endregion
        }
    }
}
