// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Storage.Fluent;

namespace ManageNetworkWatcher
{
    public class Program
    {
        private static readonly string ResourceGroupName = SdkContext.RandomResourceName("rgNEMV", 24);
        private static readonly Region region = Region.USWestCentral;

        /**
         * Azure Network sample for managing network watcher -
         *  - Create Network Watcher
         *	- Manage packet capture – track traffic to and from a virtual machine
         *   	Create a VM
         *      Start a packet capture
         *      Stop a packet capture
         *      Get a packet capture
         *      Delete a packet capture
         *  - Verify IP flow – verify if traffic is allowed to or from a virtual machine
         *      Get the IP address of a NIC on a virtual machine
         *      Test IP flow on the NIC
         *  - Analyze next hop – get the next hop type and IP address for a virtual machine
         *  - Retrieve network topology for a resource group
         *  - Analyze Virtual Machine Security by examining effective network security rules applied to a VM
         *      Get security group view for the VM
         *  - Configure Network Security Group Flow Logs
         *      Get flow log settings
         *      Enable NSG flow log
         *      Disable NSG flow log
         *  - Delete network watcher
         */
        public static void RunSample(IAzure azure)
        {
            string nwName = SdkContext.RandomResourceName("nw", 8);

            string userName = "tirekicker";
            string vnetName = SdkContext.RandomResourceName("vnet", 20);
            string subnetName = "subnet1";
            string nsgName = SdkContext.RandomResourceName("nsg", 20);
            string dnsLabel = SdkContext.RandomResourceName("pipdns", 20);
            string rgName = SdkContext.RandomResourceName("rg", 24);
            string saName = SdkContext.RandomResourceName("sa", 24);
            string vmName = SdkContext.RandomResourceName("vm", 24);
            string packetCaptureName = SdkContext.RandomResourceName("pc", 8);
            INetworkWatcher nw = null;
            try
            {
                //============================================================
                // Create network watcher
                Utilities.Log("Creating network watcher...");
                nw = azure.NetworkWatchers.Define(nwName)
                    .WithRegion(region)
                    .WithNewResourceGroup()
                    .Create();

                Utilities.Log("Created network watcher");
                // Print the network watcher
                Utilities.Print(nw);

                //============================================================
                // Manage packet capture – track traffic to and from a virtual machine

                // Create network security group, virtual network and VM; add packetCapture extension to enable packet capture
                Utilities.Log("Creating network security group...");
                INetworkSecurityGroup nsg = azure.NetworkSecurityGroups.Define(nsgName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .DefineRule("DenyInternetInComing")
                        .DenyInbound()
                        .FromAddress("INTERNET")
                        .FromAnyPort()
                        .ToAnyAddress()
                        .ToPort(443)
                        .WithAnyProtocol()
                        .Attach()
                    .Create();
                Utilities.Log("Creating virtual network...");
                ICreatable<INetwork> virtualNetwork = azure.Networks.Define(vnetName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .WithAddressSpace("192.168.0.0/16")
                    .DefineSubnet(subnetName)
                        .WithAddressPrefix("192.168.2.0/24")
                        .WithExistingNetworkSecurityGroup(nsg)
                        .Attach();
                Utilities.Log("Creating virtual machine...");
                IVirtualMachine vm = azure.VirtualMachines.Define(vmName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .WithNewPrimaryNetwork(virtualNetwork)
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithNewPrimaryPublicIPAddress(dnsLabel)
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer14_04_Lts)
                    .WithRootUsername(userName)
                    .WithRootPassword("Abcdef.123456")
                    .WithSize(VirtualMachineSizeTypes.StandardA1)
                    .DefineNewExtension("packetCapture")
                        .WithPublisher("Microsoft.Azure.NetworkWatcher")
                        .WithType("NetworkWatcherAgentLinux")
                        .WithVersion("1.4")
                        .WithMinorVersionAutoUpgrade()
                        .Attach()
                    .Create();

                // Create storage account
                Utilities.Log("Creating storage account...");
                IStorageAccount storageAccount = azure.StorageAccounts.Define(saName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .Create();

                // Start a packet capture
                Utilities.Log("Creating packet capture...");
                IPacketCapture packetCapture = nw.PacketCaptures
                    .Define(packetCaptureName)
                    .WithTarget(vm.Id)
                    .WithStorageAccountId(storageAccount.Id)
                    .WithTimeLimitInSeconds(1500)
                    .DefinePacketCaptureFilter
                        .WithProtocol(PcProtocol.TCP)
                        .Attach()
                    .Create();
                Utilities.Log("Created packet capture");
                Utilities.Print(packetCapture);

                // Stop a packet capture
                Utilities.Log("Stopping packet capture...");
                packetCapture.Stop();
                Utilities.Print(packetCapture);

                // Get a packet capture
                Utilities.Log("Getting packet capture...");
                IPacketCapture packetCapture1 = nw.PacketCaptures.GetByName(packetCaptureName);
                Utilities.Print(packetCapture1);

                // Delete a packet capture
                Utilities.Log("Deleting packet capture");
                nw.PacketCaptures.DeleteByName(packetCapture.Name);

                //============================================================
                // Verify IP flow – verify if traffic is allowed to or from a virtual machine
                // Get the IP address of a NIC on a virtual machine
                String ipAddress = vm.GetPrimaryNetworkInterface().PrimaryPrivateIP;
                // Test IP flow on the NIC
                Utilities.Log("Verifying IP flow for vm id " + vm.Id + "...");
                IVerificationIPFlow verificationIPFlow = nw.VerifyIPFlow
                    .WithTargetResourceId(vm.Id)
                    .WithDirection(Direction.Outbound)
                    .WithProtocol(Protocol.TCP)
                    .WithLocalIPAddress(ipAddress)
                    .WithRemoteIPAddress("8.8.8.8")
                    .WithLocalPort("443")
                    .WithRemotePort("443")
                    .Execute();
                Utilities.Print(verificationIPFlow);

                //============================================================
                // Analyze next hop – get the next hop type and IP address for a virtual machine
                Utilities.Log("Calculating next hop...");
                INextHop nextHop = nw.NextHop.WithTargetResourceId(vm.Id)
                    .WithSourceIPAddress(ipAddress)
                    .WithDestinationIPAddress("8.8.8.8")
                    .Execute();
                Utilities.Print(nextHop);

                //============================================================
                // Retrieve network topology for a resource group
                Utilities.Log("Getting topology...");
                ITopology topology = nw.GetTopology(rgName);
                Utilities.Print(topology);

                //============================================================
                // Analyze Virtual Machine Security by examining effective network security rules applied to a VM
                // Get security group view for the VM
                Utilities.Log("Getting security group view for a vm");
                ISecurityGroupView sgViewResult = nw.GetSecurityGroupView(vm.Id);
                Utilities.Print(sgViewResult);

                //============================================================
                // Configure Network Security Group Flow Logs

                // Get flow log settings
                IFlowLogSettings flowLogSettings = nw.GetFlowLogSettings(nsg.Id);
                Utilities.Print(flowLogSettings);

                // Enable NSG flow log
                flowLogSettings.Update()
                    .WithLogging()
                    .WithStorageAccount(storageAccount.Id)
                    .WithRetentionPolicyDays(5)
                    .WithRetentionPolicyEnabled()
                    .Apply();
                Utilities.Print(flowLogSettings);

                // Disable NSG flow log
                flowLogSettings.Update()
                    .WithoutLogging()
                    .Apply();
                Utilities.Print(flowLogSettings);

                //============================================================
                // Delete network watcher
                Utilities.Log("Deleting network watcher");
                azure.NetworkWatchers.DeleteById(nw.Id);
                Utilities.Log("Deleted network watcher");
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                    if (nw != null)
                    {
                        Utilities.Log("Deleting network watcher resource group: " + nw.ResourceGroupName);
                        azure.ResourceGroups.BeginDeleteByName(nw.ResourceGroupName);
                    }
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception ex)
                {
                    Utilities.Log(ex);
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials =
                    SdkContext.AzureCredentialsFactory.FromFile(
                        Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure.Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);
                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}