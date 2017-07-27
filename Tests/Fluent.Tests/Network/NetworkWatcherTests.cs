using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Tests;
using Fluent.Tests.Common;
using Fluent.Tests.Compute;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Xunit.Abstractions;

namespace Fluent.Tests.Network
{
    public class NetworkWatcher
    {
        private static Region REGION = Region.USWest;

        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string newName = SdkContext.RandomResourceName("nw", 6);
                var groupName = SdkContext.RandomResourceName("rg", 6);

                // Create network watcher
                var manager = TestHelper.CreateNetworkManager();
                var nw = manager.NetworkWatchers.Define(newName)
                    .WithRegion(REGION)
                    .WithNewResourceGroup(groupName)
                    .WithTag("tag1", "value1")
                    .Create();
                var resource = manager.NetworkWatchers.GetByResourceGroup(groupName, newName);
                resource = resource.Update()
                    .WithTag("tag2", "value2")
                    .WithoutTag("tag1")
                    .Apply();
                Assert.True(resource.Tags.ContainsKey("tag2"));
                Assert.True(!resource.Tags.ContainsKey("tag1"));
                manager.NetworkWatchers.DeleteById(resource.Id);
                manager.ResourceManager.ResourceGroups.DeleteByName(groupName);
            }
        }

        [Fact]
        public void CanWatchNetwork()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string newName = SdkContext.RandomResourceName("nw", 6);
                var groupName = SdkContext.RandomResourceName("rg", 6);
                var resourcesGroupName = SdkContext.RandomResourceName("rg", 8);

                // Create network watcher
                var manager = TestHelper.CreateNetworkManager();
                var computeManager = TestHelper.CreateComputeManager();
                var nw = manager.NetworkWatchers.Define(newName)
                    .WithRegion(REGION)
                    .WithNewResourceGroup(groupName)
                    .Create();

                // pre-create VMs to show topology on
                ICreatedResources<IVirtualMachine> virtualMachines = EnsureNetwork(manager, computeManager, resourcesGroupName);
                var vm0 = virtualMachines.ElementAt(0);
                ITopology topology = nw.GetTopology(vm0.ResourceGroupName);
                Assert.Equal(11, topology.Resources.Count);
                Assert.True(topology.Resources.ContainsKey(vm0.PrimaryNetworkInterfaceId));
                Assert.Equal(4, topology.Resources[vm0.PrimaryNetworkInterfaceId].Associations.Count);

                ISecurityGroupView sgViewResult = nw.GetSecurityGroupView(virtualMachines.ElementAt(0).Id);
                Assert.Equal(1, sgViewResult.NetworkInterfaces.Count);
                Assert.Equal(virtualMachines.ElementAt(0).PrimaryNetworkInterfaceId,
                    sgViewResult.NetworkInterfaces.Keys.First());

                IFlowLogSettings flowLogSettings =
                    nw.GetFlowLogSettings(vm0.GetPrimaryNetworkInterface().NetworkSecurityGroupId);
                IStorageAccount storageAccount = EnsureStorageAccount(resourcesGroupName);
                flowLogSettings.Update()
                    .WithLogging()
                    .WithStorageAccount(storageAccount.Id)
                    .WithRetentionPolicyDays(5)
                    .WithRetentionPolicyEnabled()
                    .Apply();
                Assert.Equal(true, flowLogSettings.Enabled);
                Assert.Equal(5, flowLogSettings.RetentionDays);
                Assert.Equal(storageAccount.Id, flowLogSettings.StorageId);

                INextHop nextHop = nw.NextHop.WithTargetResourceId(vm0.Id)
                    .WithSourceIPAddress("10.0.0.4")
                    .WithDestinationIPAddress("8.8.8.8")
                    .Execute();
                Assert.Equal("System Route", nextHop.RouteTableId);
                Assert.Equal(NextHopType.Internet, nextHop.NextHopType);
                Assert.Null(nextHop.NextHopIpAddress);

                IVerificationIPFlow verificationIPFlow = nw.VerifyIPFlow
                    .WithTargetResourceId(vm0.Id)
                    .WithDirection(Direction.Outbound)
                    .WithProtocol(Protocol.TCP)
                    .WithLocalIPAddress("10.0.0.4")
                    .WithRemoteIPAddress("8.8.8.8")
                    .WithLocalPort("443")
                    .WithRemotePort("443")
                    .Execute();
                Assert.Equal(Access.Allow, verificationIPFlow.Access);
                Assert.Equal("defaultSecurityRules/AllowInternetOutBound", verificationIPFlow.RuleName);

                // test packet capture
                IEnumerable<IPacketCapture> packetCaptures = nw.PacketCaptures.List();
                Assert.Equal(0, packetCaptures.Count());
                IPacketCapture packetCapture = nw.PacketCaptures
                    .Define("NewPacketCapture")
                    .WithTarget(vm0.Id)
                    .WithStorageAccountId(storageAccount.Id)
                    .WithTimeLimitInSeconds(1500)
                    .DefinePacketCaptureFilter
                        .WithProtocol(PcProtocol.TCP)
                        .WithLocalIPAddresses(new List<string>(){"127.0.0.1", "127.0.0.5"})
                        .Attach()
                    .Create();
                packetCaptures = nw.PacketCaptures.List();
                Assert.Equal(1, packetCaptures.Count());
                Assert.Equal("NewPacketCapture", packetCapture.Name);
                Assert.Equal(1500, packetCapture.TimeLimitInSeconds);
                Assert.Equal(PcProtocol.TCP.Value, packetCapture.Filters[0].Protocol);
                Assert.Equal("127.0.0.1;127.0.0.5", packetCapture.Filters[0].LocalIPAddress);
                //        Assert.assertEquals("Running", packetCapture.getStatus().packetCaptureStatus().toString());
                packetCapture.Stop();
                Assert.Equal("Stopped", packetCapture.GetStatus().PacketCaptureStatus.Value);
                nw.PacketCaptures.DeleteByName(packetCapture.Name);

                computeManager.VirtualMachines.DeleteById(virtualMachines.ElementAt(1).Id);
                topology.Refresh();
                Assert.Equal(10, topology.Resources.Count);

                manager.ResourceManager.ResourceGroups.DeleteByName(nw.ResourceGroupName);
                manager.ResourceManager.ResourceGroups.DeleteByName(resourcesGroupName);
            }
        }

        // Helper method to pre-create infrastructure to test Network Watcher
        ICreatedResources<IVirtualMachine> EnsureNetwork(INetworkManager networkManager, IComputeManager computeManager, String groupName)
        {
            IVirtualMachines vms = computeManager.VirtualMachines;
            
            // Create an NSG
            INetworkSecurityGroup nsg = networkManager.NetworkSecurityGroups.Define(SdkContext.RandomResourceName("nsg", 8))
                .WithRegion(REGION)
                .WithNewResourceGroup(groupName)
                .Create();

            // Create a network for the VMs
            INetwork network = networkManager.Networks.Define(SdkContext.RandomResourceName("net", 8))
                .WithRegion(REGION)
                .WithExistingResourceGroup(groupName)
                .WithAddressSpace("10.0.0.0/28")
                .DefineSubnet("subnet1")
                    .WithAddressPrefix("10.0.0.0/29")
                    .WithExistingNetworkSecurityGroup(nsg)
                    .Attach()
                .WithSubnet("subnet2", "10.0.0.8/29")
                .Create();

            INetworkInterface nic = networkManager.NetworkInterfaces.Define(SdkContext.RandomResourceName("ni", 8))
                .WithRegion(REGION)
                .WithExistingResourceGroup(groupName)
                .WithNewPrimaryNetwork("10.0.0.0/28")
                .WithPrimaryPrivateIPAddressDynamic()
                .WithNewPrimaryPublicIPAddress(SdkContext.RandomResourceName("pip", 8))
                .WithIPForwarding()
                .WithExistingNetworkSecurityGroup(nsg)
                .Create();

            // Create the requested number of VM definitions
            String userName = "testuser";
            var vmDefinitions = new List<ICreatable<IVirtualMachine>>();

            var vm1 = vms.Define(SdkContext.RandomResourceName("vm", 15))
                .WithRegion(REGION)
                .WithExistingResourceGroup(groupName)
                .WithExistingPrimaryNetworkInterface(nic)
                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer14_04_Lts)
                .WithRootUsername(userName)
                .WithRootPassword("Abcdef.123456")
                .WithSize(VirtualMachineSizeTypes.StandardA1)
                .DefineNewExtension("packetCapture")
                    .WithPublisher("Microsoft.Azure.NetworkWatcher")
                    .WithType("NetworkWatcherAgentLinux")
                    .WithVersion("1.4")
                    .WithMinorVersionAutoUpgrade()
                    .Attach();

            String vmName = SdkContext.RandomResourceName("vm", 15);

            ICreatable<IVirtualMachine> vm2 = vms.Define(vmName)
                .WithRegion(REGION)
                .WithExistingResourceGroup(groupName)
                .WithExistingPrimaryNetwork(network)
                .WithSubnet(network.Subnets.Values.First().Name)
                .WithPrimaryPrivateIPAddressDynamic()
                .WithoutPrimaryPublicIPAddress()
                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer14_04_Lts)
                .WithRootUsername(userName)
                .WithRootPassword("Abcdef.123456")
                .WithSize(VirtualMachineSizeTypes.StandardA1);

            vmDefinitions.Add(vm1);
            vmDefinitions.Add(vm2);
            vms.Create(vmDefinitions);
            var createdVMs2 = vms.Create(vmDefinitions);
            return createdVMs2;
        }

        // create a storage account
        IStorageAccount EnsureStorageAccount(String groupName)
        {
            return TestHelper.CreateStorageManager().StorageAccounts.Define(SdkContext.RandomResourceName("sa", 8))
                .WithRegion(REGION)
                .WithExistingResourceGroup(groupName)
                .Create();
        }
    }
}