#region Snippet:Using_Statements
using System;
using System.Linq;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
#endregion Snippet:Readme_AuthClient
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    internal class MigrationGuide
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task MigrationExample()
        {
            #region Snippet:Construct_Client
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            #endregion

            #region Snippet:Create_ResourceGroup
            Subscription subscription = armClient.DefaultSubscription;
            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();

            Location location = Location.WestUS2;
            string rgName = "QuickStartRG";

            ResourceGroupData rgData = new ResourceGroupData(location);
            ResourceGroupCreateOrUpdateOperation rgCreateLro = await rgContainer.CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup resourceGroup = rgCreateLro.Value;
            #endregion

            #region Snippet:Create_AvailabilitySet
            string vmName = "quickstartvm";
            AvailabilitySetData aSetData = new AvailabilitySetData(location);
            AvailabilitySetCreateOrUpdateOperation asetCreateLro = await resourceGroup.GetAvailabilitySets().CreateOrUpdateAsync(vmName + "_aSet", aSetData);
            AvailabilitySet aset = asetCreateLro.Value;
            string asetId = aset.Id;
            #endregion

            #region Snippet:Create_Vnet_and_Subnet
            string vnetName = "MYVM" + "_vnet";
            string subnetName = "mySubnet";
            AddressSpace addressSpace = new AddressSpace();
            addressSpace.AddressPrefixes.Add("10.0.0.0/16");

            VirtualNetworkData vnetData = new VirtualNetworkData()
            {
                AddressSpace = addressSpace,
                Subnets =
                {
                    new SubnetData()
                    {
                        Name = subnetName,
                        AddressPrefix = "10.0.0.0/24"
                    }
                }
            };
            VirtualNetworkCreateOrUpdateOperation vnetCreateLro = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(vnetName, vnetData);
            VirtualNetwork vnet = vnetCreateLro.Value;
            #endregion

            #region Snippet:Create_NetworkSecurityGroup
            string nsgName = vmName + "_nsg";
            NetworkSecurityGroupData nsgData = new NetworkSecurityGroupData() { Location = location };
            NetworkSecurityGroupCreateOrUpdateOperation nsgCreateLro = await resourceGroup.GetNetworkSecurityGroups().CreateOrUpdateAsync(nsgName, nsgData);
            NetworkSecurityGroup nsg = nsgCreateLro.Value;
            #endregion

            #region Snippet:Create_NetworkInterface
            string nicName = vmName + "_nic";
            NetworkInterfaceIPConfiguration nicIPConfig = new NetworkInterfaceIPConfiguration()
            {
                Name = "Primary",
                Primary = true,
                Subnet = new SubnetData() { Id = vnet.Data.Subnets.First().Id },
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
            };

            NetworkInterfaceData nicData = new NetworkInterfaceData();
            nicData.Location = location;
            nicData.IpConfigurations.Add(nicIPConfig);
            NetworkInterfaceCreateOrUpdateOperation nicCreateLro = await resourceGroup.GetNetworkInterfaces().CreateOrUpdateAsync(nicName, nicData);
            NetworkInterface nic = nicCreateLro.Value;
            #endregion

            #region Snippet:Create_VirtualMachine
            VirtualMachineData vmData = new VirtualMachineData(location);
            vmData.OsProfile.AdminUsername = "admin-username";
            vmData.OsProfile.AdminPassword = "admin-p4$$w0rd";
            vmData.OsProfile.ComputerName = "computer-name";
            //vmData.AvailabilitySet = new WritableSubResource(); // Uncomment when package is updated
            vmData.AvailabilitySet.Id = aset.Id;
            NetworkInterfaceReference nicReference = new NetworkInterfaceReference();
            nicReference.Id = nic.Id;
            vmData.NetworkProfile.NetworkInterfaces.Add(nicReference);

            VirtualMachine vm = (await resourceGroup.GetVirtualMachines().CreateOrUpdateAsync(vmName, vmData)).Value;
            Console.WriteLine("VM ID: " + vm.Id);
            #endregion
        }
    }
}
