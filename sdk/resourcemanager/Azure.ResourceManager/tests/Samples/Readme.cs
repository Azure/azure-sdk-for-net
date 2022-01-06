#region Snippet:Readme_AuthClient
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using System;
using System.Threading.Tasks;
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
            string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet";
            ResourceIdentifier id = new ResourceIdentifier(resourceId);
            Console.WriteLine($"Subscription: {id.SubscriptionId}");
            Console.WriteLine($"ResourceGroup: {id.ResourceGroupName}");
            Console.WriteLine($"Vnet: {id.Parent.Name}");
            Console.WriteLine($"Subnet: {id.Name}");
            #endregion Snippet:Readme_CastToSpecificType
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CastingToBaseResourceIdentifier()
        {
            #region Snippet:Readme_CastToBaseResourceIdentifier
            string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet";
            ResourceIdentifier id = new ResourceIdentifier(resourceId);
            Console.WriteLine($"Subscription: {id.SubscriptionId}");
            Console.WriteLine($"ResourceGroup: {id.ResourceGroupName}");
            // Parent is only null when we reach the top of the chain which is a Tenant
            Console.WriteLine($"Vnet: {id.Parent.Name}");
            // Name will never be null
            Console.WriteLine($"Subnet: {id.Name}");
            #endregion Snippet:Readme_CastToBaseResourceIdentifier
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CheckIfResourceGroupExists()
        {
            #region Snippet:Readme_CheckIfExistssRG
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            string rgName = "myRgName";

            bool exists = await subscription.GetResourceGroups().CheckIfExistsAsync(rgName);

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
            #endregion Snippet:Readme_CheckIfExistssRG
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
            #region Snippet:Readme_OldCheckIfExistsRG
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
            #endregion Snippet:Readme_OldCheckIfExistsRG
        }
    }
}
