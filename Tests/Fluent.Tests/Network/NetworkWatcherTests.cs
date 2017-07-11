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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Fluent.Tests.Network
{
    public class NetworkWatcher
    {
        private static Region REGION = Region.USWest;
        private static string GROUP_NAME = "rg" + SdkContext.RandomResourceName("", 8);
        private static string TEST_ID = SdkContext.RandomResourceName("", 8);

        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");

                string newName = "nw" + testId;
                var groupName = "rg" + testId;

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
                var testId = TestUtilities.GenerateName("");

                string newName = "nw" + testId;
                var groupName = "rg" + testId;

                // Create network watcher
                var manager = TestHelper.CreateNetworkManager();
                var computeManager = TestHelper.CreateComputeManager();
                var nw = manager.NetworkWatchers.Define(newName)
                    .WithRegion(REGION)
                    .WithNewResourceGroup(groupName)
                    .Create();

                // pre-create VMs to show topology on
                ICreatedResources<IVirtualMachine> virtualMachines = EnsureNetwork(manager, computeManager);

                ITopology topology = nw.GetTopology(virtualMachines.ElementAt(0).ResourceGroupName);
                Assert.Equal(11, topology.Resources.Count);
//                Assert.True(topology.Resources.ContainsKey(virtualMachines.ElementAt(0).PrimaryNetworkInterface()
//                    .networkSecurityGroupId()));
//                Assert.Equal(4,
//                    topology.Resources.Get(virtualMachines[0].primaryNetworkInterfaceId()).associations().size());

                ISecurityGroupView sgViewResult = nw.GetSecurityGroupView(virtualMachines.ElementAt(0).Id);
                Assert.Equal(1, sgViewResult.NetworkInterfaces.Count);
                Assert.Equal(virtualMachines.ElementAt(0).PrimaryNetworkInterfaceId,
                    sgViewResult.NetworkInterfaces.Keys.First());

//                IFlowLogSettings flowLogSettings =
//                    nw.GetFlowLogSettings(virtualMachines.ElementAt(0).getPrimaryNetworkInterface().networkSecurityGroupId());
//                IStorageAccount storageAccount = EnsureStorageAccount();
//                flowLogSettings.Update()
//                    .WithLogging()
//                    .WithStorageAccount(storageAccount.Id)
//                    .WithRetentionPolicyDays(5)
//                    .WithRetentionPolicyEnabled()
//                    .Apply();
//                Assert.Equal(true, flowLogSettings.Enabled);
//                Assert.Equal(5, flowLogSettings.RetentionDays);
//                Assert.Equal(storageAccount.Id, flowLogSettings.StorageId);

                //        Troubleshooting troubleshooting = nw.troubleshoot(<virtual_network_gateway_id> or <virtual_network_gateway_connaction_id>,
                //                storageAccount.id(), "");
                INextHop nextHop = nw.NextHop.WithTargetResourceId(virtualMachines.ElementAt(0).Id)
                    .WithSourceIPAddress("10.0.0.4")
                    .WithDestinationIPAddress("8.8.8.8")
                    .Execute();
                Assert.Equal("System Route", nextHop.RouteTableId);
                Assert.Equal(NextHopType.Internet, nextHop.NextHopType);
                Assert.Null(nextHop.NextHopIpAddress);

                IVerificationIPFlow verificationIPFlow = nw.VerifyIPFlow
                    .WithTargetResourceId(virtualMachines.ElementAt(0).Id)
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
//                IPacketCapture packetCapture = nw.PacketCaptures
//                    .Define("NewPacketCapture")
//                    .WithTarget(virtualMachines.ElementAt(0).Id)
//                    .WithStorageAccountId(storageAccount.Id)
//                    .WithTimeLimitInSeconds(1500)
//                    .DefinePacketCaptureFilter()
//                    .WithProtocol(PcProtocol.TCP)
//                    .WithLocalIPAddresses(Arrays.asList("127.0.0.1", "127.0.0.5"))
//                    .attach()
//                    .create();
//                packetCaptures = nw.packetCaptures().list();
//                Assert.Equal(1, packetCaptures.Count());
//                Assert.assertEquals("NewPacketCapture", packetCapture.name());
//                Assert.assertEquals(1500, packetCapture.timeLimitInSeconds());
//                Assert.assertEquals(PcProtocol.TCP, packetCapture.filters().get(0).protocol());
//                Assert.assertEquals("127.0.0.1;127.0.0.5", packetCapture.filters().get(0).localIPAddress());
//                //        Assert.assertEquals("Running", packetCapture.getStatus().packetCaptureStatus().toString());
//                packetCapture.Stop();
//                Assert.assertEquals("Stopped", packetCapture.GetStatus().PacketCaptureStatus.Value);
//                nw.PacketCaptures.DeleteByName(packetCapture.Name);

                computeManager.VirtualMachines.DeleteById(virtualMachines.ElementAt(1).Id);
                topology.Refresh();
                Assert.Equal(10, topology.Resources.Count);

                manager.ResourceManager.ResourceGroups.DeleteByName(nw.ResourceGroupName);
                manager.ResourceManager.ResourceGroups.DeleteByName(GROUP_NAME);
            }
        }

        // Helper method to pre-create infrastructure to test Network Watcher
        ICreatedResources<IVirtualMachine> EnsureNetwork(INetworkManager networkManager, IComputeManager computeManager)
        {
            IVirtualMachines vms = computeManager.VirtualMachines;
            
            // Create an NSG
            INetworkSecurityGroup nsg = networkManager.NetworkSecurityGroups.Define("nsg" + TEST_ID)
                .WithRegion(REGION)
                .WithNewResourceGroup(GROUP_NAME)
                .Create();

            // Create a network for the VMs
            INetwork network = networkManager.Networks.Define("net" + TEST_ID)
                .WithRegion(REGION)
                .WithExistingResourceGroup(GROUP_NAME)
                .WithAddressSpace("10.0.0.0/28")
                .DefineSubnet("subnet1")
                    .WithAddressPrefix("10.0.0.0/29")
                    .WithExistingNetworkSecurityGroup(nsg)
                    .Attach()
                .WithSubnet("subnet2", "10.0.0.8/29")
                .Create();

            INetworkInterface nic = networkManager.NetworkInterfaces.Define("ni" + TEST_ID)
                .WithRegion(REGION)
                .WithExistingResourceGroup(GROUP_NAME)
                .WithNewPrimaryNetwork("10.0.0.0/28")
                .WithPrimaryPrivateIPAddressDynamic()
                .WithNewPrimaryPublicIPAddress("pipdns" + TEST_ID)
                .WithIPForwarding()
                .WithExistingNetworkSecurityGroup(nsg)
                .Create();

            // Create the requested number of VM definitions
            String userName = "testuser" + TEST_ID;
            var vmDefinitions = new List<ICreatable<IVirtualMachine>>();

            var vm1 = vms.Define(SdkContext.RandomResourceName("vm", 15))
                .WithRegion(REGION)
                .WithExistingResourceGroup(GROUP_NAME)
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
                .WithExistingResourceGroup(GROUP_NAME)
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
        IStorageAccount EnsureStorageAccount()
        {
            return TestHelper.CreateStorageManager().StorageAccounts.Define("sa" + TEST_ID)
                .WithRegion(REGION)
                .WithExistingResourceGroup(GROUP_NAME)
                .Create();
        }
    }
}