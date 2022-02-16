#region Snippet:Readme_AuthClient
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Resources;
#if !SNIPPET
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    class Readme
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ClientAuth()
        {
#endif

// Code omitted for brevity

ArmClient armClient = new ArmClient(new DefaultAzureCredential());
#endregion Snippet:Readme_AuthClient
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CastingToSpecificType()
        {
            #region Snippet:Readme_CastToSpecificType
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet");
            Console.WriteLine($"Subscription: {id.SubscriptionId}");
            Console.WriteLine($"ResourceGroup: {id.ResourceGroupName}");
            Console.WriteLine($"Vnet: {id.Parent.Name}");
            Console.WriteLine($"Subnet: {id.Name}");
            #endregion Snippet:Readme_CastToSpecificType
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CheckIfResourceGroupExists()
        {
            #region Snippet:Readme_ExistsRG
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            string rgName = "myRgName";

            bool exists = await subscription.GetResourceGroups().ExistsAsync(rgName);

            if (exists)
            {
                Console.WriteLine($"Resource Group {rgName} exists.");

                // We can get the resource group now that we know it exists.
                // This does introduce a small race condition where resource group could have been deleted between the check and the get.
                ResourceGroup myRG = await subscription.GetResourceGroups().GetAsync(rgName);
            }
            else
            {
                Console.WriteLine($"Resource Group {rgName} does not exist.");
            }
            #endregion Snippet:Readme_ExistsRG
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task TryGetResourceGroup()
        {
            #region Snippet:Readme_TryGetRG
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            string rgName = "myRgName";

            ResourceGroup myRG = await subscription.GetResourceGroups().GetIfExistsAsync(rgName);

            if (myRG == null)
            {
                Console.WriteLine($"Resource Group {rgName} does not exist.");
            }
            else
            {
                // At this point, we are sure that myRG is a not null Resource Group, so we can use this object to perform any operations we want.
            }
            #endregion Snippet:Readme_TryGetRG
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task TryGetResourceGroupOld()
        {
            #region Snippet:Readme_OldExistsRG
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            string rgName = "myRgName";

            try
            {
                ResourceGroup myRG = await subscription.GetResourceGroups().GetAsync(rgName);
                // At this point, we are sure that myRG is a not null Resource Group, so we can use this object to perform any operations we want.
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Resource Group {rgName} does not exist.");
            }
            #endregion Snippet:Readme_OldExistsRG
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task LoopVms()
        {
            #region Snippet:Readme_LoopVms
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            string rgName = "myResourceGroup";
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync(rgName);
            await foreach (VirtualMachine vm in rg.GetVirtualMachines())
            {
                //previously we would have to take the resourceGroupName and the vmName from the vm object
                //and pass those into the powerOff method as well as we would need to execute that on a separate compute client
                await vm.PowerOffAsync(true);
            }
            #endregion Snippet:Readme_LoopVms
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task PuttingItAllTogether()
        {
            #region Snippet:Readme_PuttingItAllTogether
            // First we construct our armClient
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());

            // Next we get a resource group object
            // ResourceGroup is a [Resource] object from above
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync("myRgName");

            // Next we get the collection for the virtual machines
            // vmCollection is a [Resource]Collection object from above
            VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();

            // Next we loop over all vms in the collection
            // Each vm is a [Resource] object from above
            await foreach (VirtualMachine vm in vmCollection)
            {
                // We access the [Resource]Data properties from vm.Data
                if (!vm.Data.Tags.ContainsKey("owner"))
                {
                    // We can also access all operations from vm since it is already scoped for us
                    await vm.AddTagAsync("owner", "tagValue");
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
            // We construct a new armClient to work with
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Next we get the specific subscription this resource belongs to
            Subscription subscription = await armClient.GetSubscriptions().GetAsync(id.SubscriptionId);
            // Next we get the specific resource group this resource belongs to
            ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(id.ResourceGroupName);
            // Finally we get the resource itself
            // Note: for this last step in this example, Azure.ResourceManager.Compute is needed
            AvailabilitySet availabilitySet = await resourceGroup.GetAvailabilitySets().GetAsync(id.Name);
            #endregion Snippet:Readme_ManageAvailabilitySetOld
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ManageAvailabilitySetNow()
        {
            #region Snippet:Readme_ManageAvailabilitySetNow
            ResourceIdentifier resourceId = new ResourceIdentifier("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Compute/availabilitySets/ws2021availSet");
            // We construct a new armClient to work with
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Next we get the AvailabilitySet resource client from the armClient
            // The method takes in a ResourceIdentifier but we can use the implicit cast from string
            AvailabilitySet availabilitySet = armClient.GetAvailabilitySet(resourceId);
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
            ResourceIdentifier resourceId = AvailabilitySet.CreateResourceIdentifier(subscriptionId, resourceGroupName, availabilitySetName);
            // We construct a new armClient to work with
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Next we get the AvailabilitySet resource client from the armClient
            // The method takes in a ResourceIdentifier but we can use the implicit cast from string
            AvailabilitySet availabilitySet = armClient.GetAvailabilitySet(resourceId);
            // At this point availabilitySet.Data will be null and trying to access it will throw
            // If we want to retrieve the objects data we can simply call get
            availabilitySet = await availabilitySet.GetAsync();
            // we now have the data representing the availabilitySet
            Console.WriteLine(availabilitySet.Data.Name);
            #endregion Snippet:Readme_ManageAvailabilitySetPieces
        }
    }
}
