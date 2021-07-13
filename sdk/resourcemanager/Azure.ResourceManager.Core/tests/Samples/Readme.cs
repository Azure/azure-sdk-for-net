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
        public async Task CreateRG()
        {
            #region Snippet:Readme_CreateRG
            // First, initialize the ArmClient and get the default subscription
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            // Now we get a ResourceGroup container for that subscription
            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();

            // With the container, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS;
            ResourceGroup resourceGroup = await rgContainer.Construct(location).CreateOrUpdateAsync(rgName);
            #endregion Snippet:Readme_CreateRG
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListAllRG()
        {
            #region Snippet:Readme_ListAllRG
            // First, initialize the ArmClient and get the default subscription
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;

            // Now we get a ResourceGroup container for that subscription
            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();

            // With ListAsync(), we can get a list of the resources in the container
            AsyncPageable<ResourceGroup> response = rgContainer.ListAsync();
            await foreach (ResourceGroup rg in response)
            {
                Console.WriteLine(rg.Data.Name);
            }
            #endregion Snippet:Readme_ListAllRG
        }
    }
}
