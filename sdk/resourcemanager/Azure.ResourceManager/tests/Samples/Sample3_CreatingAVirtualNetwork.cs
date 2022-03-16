using System.Threading.Tasks;
using Azure.Core;
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
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

            string resourceGroupName = "myResourceGroup";
            ResourceGroupData resourceGroupData = new ResourceGroupData(AzureLocation.WestUS2);
            ArmOperation<ResourceGroup> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
            ResourceGroup resourceGroup = operation.Value;
            #endregion Snippet:Creating_A_Virtual_Network_CreateResourceGroup
        }
    }
}
