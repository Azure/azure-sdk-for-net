#region Snippet:Readme_AuthClient
using Azure.Identity;
using Azure.ResourceManager.Core;
using System;
using System.Threading.Tasks;
#if !SNIPPET
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests.Samples
{
    class Readme
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ClientAuth()
        {
#endif

// Code omitted for brevity

var armClient = new ArmClient(new DefaultAzureCredential());
#endregion Snippet:Readme_AuthClient
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CastingToSpecificType()
        {
            #region Snippet:Readme_CastToSpecificType
            string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet";
            // We know the subnet is a resource group level identifier since it has a resource group name in its string
            ResourceGroupResourceIdentifier id = resourceId;
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
            // Assume we don't know what type of resource id we have we can cast to the base type
            ResourceIdentifier id = resourceId;
            string property;
            if (id.TryGetSubscriptionId(out property))
                Console.WriteLine($"Subscription: {property}");
            if (id.TryGetResourceGroupName(out property))
                Console.WriteLine($"ResourceGroup: {property}");
            Console.WriteLine($"Vnet: {id.Parent.Name}");
            Console.WriteLine($"Subnet: {id.Name}");
            #endregion Snippet:Readme_CastToBaseResourceIdentifier
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CheckIfResourceGroupExists()
        {
            #region Snippet:Readme_DoesExistsRG
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            string rgName = "myRgName";

            var exists = await subscription.GetResourceGroups().DoesExistAsync(rgName);

            if (exists)
            {
                Console.WriteLine($"Resource Group {rgName} exists.");

                // We can get the resource group now that we are sure it exists.
                var myRG = await subscription.GetResourceGroups().GetAsync(rgName);
            }
            else
            {
                Console.WriteLine($"Resource Group {rgName} does not exist.");
            }
            #endregion Snippet:Readme_DoesExistsRG
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task TryGetResourceGroup()
        {
            #region Snippet:Readme_TryGetRG
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            string rgName = "myRgName";

            var myRG = await subscription.GetResourceGroups().TryGetAsync(rgName);

            if (myRG == null)
            {
                Console.WriteLine($"Resource Group {rgName} does not exist.");
                return;
            }

            // At this point, we are sure that myRG is a not null Resource Group, so we can use this object to perform any operations we want.
            
            #endregion Snippet:Readme_TryGetRG
        }
    }
}
