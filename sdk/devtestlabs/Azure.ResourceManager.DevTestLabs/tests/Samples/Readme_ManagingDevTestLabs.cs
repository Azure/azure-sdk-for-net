// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:DevTestLabs_AuthClient_Namespaces
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.DevTestLabs;
using Azure.ResourceManager.Resources;
#endregion
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DevTestLabs.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DevTestLabs.Samples
{
    public class Readme_ManagingDevTestLabs
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ClientAuth()
        {
            #region Snippet:DevTestLabs_AuthClient
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateALab()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            string rgName = "myResourceGroup";
            AzureLocation location = AzureLocation.EastUS;
            ArmOperation<ResourceGroupResource> rgLro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = rgLro.Value;

            #region Snippet:DevTestLabs_CreateALab
            DevTestLabCollection labCollection = resourceGroup.GetDevTestLabs();
            string labName = "myLab";
            DevTestLabData labData = new DevTestLabData(location);
            ArmOperation<DevTestLabResource> lro = await labCollection.CreateOrUpdateAsync(WaitUntil.Completed, labName, labData);
            DevTestLabResource lab = lro.Value;
            Console.WriteLine($"Created lab: {lab.Data.Name}");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetALab()
        {
            #region Snippet:DevTestLabs_GetALab
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            string rgName = "myResourceGroup";
            ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
            DevTestLabCollection labCollection = resourceGroup.GetDevTestLabs();

            string labName = "myLab";
            DevTestLabResource lab = await labCollection.GetAsync(labName);
            Console.WriteLine($"Retrieved lab: {lab.Data.Name}, location: {lab.Data.Location}");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListAllLabsInResourceGroup()
        {
            #region Snippet:DevTestLabs_ListAllLabs
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            string rgName = "myResourceGroup";
            ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
            DevTestLabCollection labCollection = resourceGroup.GetDevTestLabs();

            await foreach (DevTestLabResource lab in labCollection.GetAllAsync())
            {
                Console.WriteLine($"Lab: {lab.Data.Name}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteALab()
        {
            #region Snippet:DevTestLabs_DeleteALab
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            string rgName = "myResourceGroup";
            ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);

            string labName = "myLab";
            DevTestLabResource lab = await resourceGroup.GetDevTestLabs().GetAsync(labName);
            await lab.DeleteAsync(WaitUntil.Completed);
            Console.WriteLine($"Deleted lab: {labName}");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CheckIfLabExists()
        {
            #region Snippet:DevTestLabs_CheckIfLabExists
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            string rgName = "myResourceGroup";
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);

            string labName = "myLab";
            bool exists = await resourceGroup.GetDevTestLabs().ExistsAsync(labName);

            if (exists)
            {
                Console.WriteLine($"Lab '{labName}' exists.");
            }
            else
            {
                Console.WriteLine($"Lab '{labName}' does not exist.");
            }
            #endregion
        }
    }
}
