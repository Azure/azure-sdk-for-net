using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework; 

namespace Azure.ResourceManager.Core.Tests.Samples
{
    class Sample3_CreatingAVirtualNetwork
    {
        public Sample3_CreatingAVirtualNetwork()
        {
        }

        [Test]
        public async Task CreateResourceGroupAsync()
        {
            #region Snippet:Creating_A_Virtual_Network_CreateResourceGroup
            var armClient = new ArmClient(new DefaultAzureCredential());
            ResourceGroupContainer rgContainer = armClient.DefaultSubscription.GetResourceGroups();
            string rgName = "myResourceGroup";
            ResourceGroup resourceGroup = await rgContainer.Construct(LocationData.WestUS2).CreateOrUpdateAsync(rgName);
            #endregion Snippet:Creating_A_Virtual_Network_CreateResourceGroup

            // Does this need the compute sdk?
            #region 
            //VirtualNetworkContainer vnetContainer = resourceGroup.GetVirtualNetworks();
            //VirtualNetwork virtualNetwork = await vnetContainer
            //    .Construct("10.0.0.0/16", location)
            //    .CreateAsync("myVnetName");
            #endregion
        }
    }
}
