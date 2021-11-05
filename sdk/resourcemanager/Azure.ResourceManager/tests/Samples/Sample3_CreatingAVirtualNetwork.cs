using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    class Sample3_CreatingAVirtualNetwork
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateResourceGroupAsync()
        {
            #region Snippet:Creating_A_Virtual_Network_CreateResourceGroup
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            string rgName = "myResourceGroup";
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            ResourceGroupCreateOrUpdateOperation operation = await rgCollection.CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup resourceGroup = operation.Value;
            #endregion Snippet:Creating_A_Virtual_Network_CreateResourceGroup
        }
    }
}
