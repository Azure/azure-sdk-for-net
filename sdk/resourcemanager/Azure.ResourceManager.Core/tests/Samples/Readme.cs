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

        //[Test]
        //[Ignore("Only verifying that the sample builds")]
        //public void ManagingResourceById()
        //{
        //    #region Snippet:Readme_ManagingResourceById
        //    string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Compute/availabilitySets/ws2021availSet";
        //    //we know the availability set is a resource group level identifier since it has a resource group name in its string
        //    ResourceGroupResourceIdentifier id = resourceId;
        //    //we then construct a new armClient to work with
        //    ArmClient armClient = new ArmClient(new DefaultAzureCredential());
        //    //next we get the specific subscription this resource belongs to
        //    Subscription subscription = armClient.GetSubscriptions().Get(id.SubscriptionId);
        //    //next we get the specific resource group this resource belongs to
        //    ResourceGroup resourceGroup = subscription.GetResourceGroups().Get(id.ResourceGroupName);
        //    //finally we get the resource itself
        //    AvailabilitySet availabilitySet = resourceGroup.GetAvailabilitySets().Get(id.Name);
        //    #endregion Snippet:Readme_ManagingResourceById
        //}

        //[Test]
        //[Ignore("Only verifying that the sample builds")]
        //public void ManagingResourceByIdWithExtensionMethods()
        //{
        //    #region Snippet:Readme_ManagingResourceByIdWithExtensionMethods
        //    string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Compute/availabilitySets/ws2021availSet";
        //    //we construct a new armClient to work with
        //    ArmClient armClient = new ArmClient(new DefaultAzureCredential());
        //    //next we get the AvailabilitySetOperations object from the client
        //    //the method takes in a ResourceIdentifier but we can use the implicit cast from string
        //    AvailabilitySetOperations availabilitySetOperations = armClient.GetAvailabilitySetOperations(resourceId);
        //    //now if we want to retrieve the objects data we can simply call get
        //    AvailabilitySet availabilitySet = availabilitySetOperations.Get();
        //    #endregion Snippet:Readme_ManagingResourceByIdWithExtensionMethods
        //}
    }
}
