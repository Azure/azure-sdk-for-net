// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Readme_AuthClient_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Resources;

#endregion Snippet:Readme_AuthClient_Namespaces
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    public class Readme
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ClientAuth()
        {
            #region Snippet:Readme_AuthClient
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            #endregion Snippet:Readme_AuthClient
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ClientAuthChina()
        {
            #region Snippet:Readme_AuthClientChina
            // Please replace the following placeholders with your Azure information
            string tenantId = "your-tenant-id";
            string clientId = "your-client-id";
            string clientSecret = "your-client-secret";
            string subscriptionId = "your-subscription-id";
            //ArmClientOptions to set the Azure China environment
            ArmClientOptions armOptions = new ArmClientOptions { Environment = ArmEnvironment.AzureChina };
            // AzureAuthorityHosts to set the Azure China environment
            Uri authorityHost = AzureAuthorityHosts.AzureChina;
            // Create ClientSecretCredential for authentication
            TokenCredential credential = new ClientSecretCredential(tenantId, clientId, clientSecret, new TokenCredentialOptions { AuthorityHost = authorityHost });
            // Create the Azure Resource Manager client
            ArmClient client = new ArmClient(credential, subscriptionId, armOptions);
            #endregion Snippet:Readme_AuthClientChina
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CastingToSpecificType()
        {
            #region Snippet:Readme_CastToSpecificType
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet");
            Console.WriteLine($"Subscription: {id.SubscriptionId}");
            Console.WriteLine($"ResourceGroupResource: {id.ResourceGroupName}");
            Console.WriteLine($"Vnet: {id.Parent.Name}");
            Console.WriteLine($"Subnet: {id.Name}");
            #endregion Snippet:Readme_CastToSpecificType
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CheckIfResourceGroupExists()
        {
            #region Snippet:Readme_ExistsRG
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            string resourceGroupName = "myRgName";

            bool exists = await resourceGroups.ExistsAsync(resourceGroupName);

            if (exists)
            {
                Console.WriteLine($"Resource Group {resourceGroupName} exists.");

                // We can get the resource group now that we know it exists.
                // This does introduce a small race condition where resource group could have been deleted between the check and the get.
                ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
            }
            else
            {
                Console.WriteLine($"Resource Group {resourceGroupName} does not exist.");
            }
            #endregion Snippet:Readme_ExistsRG
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task TryGetResourceGroupOld()
        {
            #region Snippet:Readme_OldExistsRG
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            string resourceGroupName = "myRgName";

            try
            {
                ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
                // At this point, we are sure that myRG is a not null Resource Group, so we can use this object to perform any operations we want.
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Resource Group {resourceGroupName} does not exist.");
            }
            #endregion Snippet:Readme_OldExistsRG
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task LoopVms()
        {
            #region Snippet:Readme_LoopVms
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            string resourceGroupName = "myResourceGroup";
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
            await foreach (VirtualMachineResource virtualMachine in resourceGroup.GetVirtualMachines())
            {
                //previously we would have to take the resourceGroupName and the vmName from the vm object
                //and pass those into the powerOff method as well as we would need to execute that on a separate compute client
                await virtualMachine.PowerOffAsync(WaitUntil.Completed);
            }
            #endregion Snippet:Readme_LoopVms
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task PuttingItAllTogether()
        {
            #region Snippet:Readme_PuttingItAllTogether
            // First we construct our client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // Next we get a resource group object
            // ResourceGroupResource is a [Resource] object from above
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            ResourceGroupResource resourceGroup = await resourceGroups.GetAsync("myRgName");

            // Next we get the collection for the virtual machines
            // vmCollection is a [Resource]Collection object from above
            VirtualMachineCollection virtualMachines = resourceGroup.GetVirtualMachines();

            // Next we loop over all vms in the collection
            // Each vm is a [Resource] object from above
            await foreach (VirtualMachineResource virtualMachine in virtualMachines)
            {
                // We access the [Resource]Data properties from vm.Data
                if (!virtualMachine.Data.Tags.ContainsKey("owner"))
                {
                    // We can also access all operations from vm since it is already scoped for us
                    await virtualMachine.AddTagAsync("owner", "tagValue");
                }
            }
            #endregion Snippet:Readme_PuttingItAllTogether
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ManageAvailabilitySetOld()
        {
            #region Snippet:Readme_ManageAvailabilitySetOld
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Compute/availabilitySets/ws2021availSet");
            // We construct a new client to work with
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            // Next we get the collection of subscriptions
            SubscriptionCollection subscriptions = client.GetSubscriptions();
            // Next we get the specific subscription this resource belongs to
            SubscriptionResource subscription = await subscriptions.GetAsync(id.SubscriptionId);
            // Next we get the collection of resource groups that belong to that subscription
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            // Next we get the specific resource group this resource belongs to
            ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(id.ResourceGroupName);
            // Next we get the collection of availability sets that belong to that resource group
            AvailabilitySetCollection availabilitySets = resourceGroup.GetAvailabilitySets();
            // Finally we get the resource itself
            // Note: for this last step in this example, Azure.ResourceManager.Compute is needed
            AvailabilitySetResource availabilitySet = await availabilitySets.GetAsync(id.Name);
            #endregion Snippet:Readme_ManageAvailabilitySetOld
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ManageAvailabilitySetNow()
        {
            #region Snippet:Readme_ManageAvailabilitySetNow
            ResourceIdentifier resourceId = new ResourceIdentifier("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Compute/availabilitySets/ws2021availSet");
            // We construct a new client to work with
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            // Next we get the AvailabilitySetResource resource client from the client
            // The method takes in a ResourceIdentifier but we can use the implicit cast from string
            AvailabilitySetResource availabilitySet = client.GetAvailabilitySetResource(resourceId);
            // At this point availabilitySet.Data will be null and trying to access it will throw
            // If we want to retrieve the objects data we can simply call get
            availabilitySet = await availabilitySet.GetAsync();
            // we now have the data representing the availabilitySet
            Console.WriteLine(availabilitySet.Data.Name);
            #endregion Snippet:Readme_ManageAvailabilitySetNow
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ManageAvailabilitySetPieces()
        {
            #region Snippet:Readme_ManageAvailabilitySetPieces
            string subscriptionId = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
            string resourceGroupName = "workshop2021-rg";
            string availabilitySetName = "ws2021availSet";
            ResourceIdentifier resourceId = AvailabilitySetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, availabilitySetName);
            // We construct a new client to work with
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            // Next we get the AvailabilitySetResource resource client from the client
            // The method takes in a ResourceIdentifier but we can use the implicit cast from string
            AvailabilitySetResource availabilitySet = client.GetAvailabilitySetResource(resourceId);
            // At this point availabilitySet.Data will be null and trying to access it will throw
            // If we want to retrieve the objects data we can simply call get
            availabilitySet = await availabilitySet.GetAsync();
            // we now have the data representing the availabilitySet
            Console.WriteLine(availabilitySet.Data.Name);
            #endregion Snippet:Readme_ManageAvailabilitySetPieces
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task LRORehydration()
        {
            #region Snippet:Readme_LRORehydration
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            var orgData = new ResourceGroupData(AzureLocation.WestUS2);
            // We initialize a long-running operation
            var rgOp = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Started, "orgName", orgData);
            // We get the rehydration token from the operation
            var rgOpRehydrationToken = rgOp.GetRehydrationToken();
            // We rehydrate the long-running operation with the rehydration token, we can also do this asynchronously
            var rehydratedOrgOperation = ArmOperation.Rehydrate<ResourceGroupResource>(client, rgOpRehydrationToken!.Value);
            var rehydratedOrgOperationAsync = await ArmOperation.RehydrateAsync<ResourceGroupResource>(client, rgOpRehydrationToken!.Value);
            // Now we can operate with the rehydrated operation
            var rawResponse = rehydratedOrgOperation.GetRawResponse();
            await rehydratedOrgOperation.WaitForCompletionAsync();
            #endregion Snippet:Readme_LRORehydration
        }
    }
}
