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

// code omitted for brevity

var armClient = new ArmClient(new DefaultAzureCredential());
#endregion Snippet:Readme_AuthClient
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CastingToSpecificType()
        {
            #region Snippet:Readme_CastToSpecificType
            string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet";
            //we know the subnet is a resource group level identifier since it has a resource group name in its string
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
            //assume we don't know what type of resource id we have we can cast to the base type
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
    }
}
