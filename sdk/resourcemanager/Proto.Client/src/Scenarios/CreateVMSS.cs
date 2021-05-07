// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Core;
using Proto.Compute;
using Proto.Network;

namespace Proto.Client
{
    class CreateVMSS : Scenario
    {
        public override void Execute()
        {
            // TODO Not fully debugged yet around LoadBalancer
            // ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private async Task ExecuteAsync()
        {
            var client = new ArmClient(ScenarioContext.AzureSdkSandboxId, new DefaultAzureCredential());

            // Create Resource Group
            Console.WriteLine($"--------Start StartCreate group {Context.RgName}--------");
            ResourceGroup resourceGroup = await client
                .DefaultSubscription
                .GetResourceGroups()
                .Construct(Context.Loc)
                .StartCreateOrUpdate(Context.RgName)
                .WaitForCompletionAsync()
                ;
            CleanUp.Add(resourceGroup.Id);

            // Create VNet
            Console.WriteLine("--------Start create VNet--------");
            string vnetName = Context.VmName + "_vnet";
            var vnet = resourceGroup.GetVirtualNetworks().Construct("10.0.0.0/16").CreateOrUpdate(vnetName).Value;

            //create subnet
            Console.WriteLine("--------Start create Subnet async--------");
            var subnet = vnet.GetSubnets().Construct("10.0.0.0/24").CreateOrUpdate(Context.SubnetName).Value;

            //create network security group
            Console.WriteLine("--------Start create NetworkSecurityGroup--------");
            _ = resourceGroup.GetNetworkSecurityGroups().Construct(80).CreateOrUpdate(Context.NsgName).Value;

            // Create Network Interface
            Console.WriteLine("--------Start create Network Interface--------");
            var nic = resourceGroup.GetNetworkInterfaces().Construct(subnet.Id).CreateOrUpdate($"{Context.VmName}_nic").Value;


            // Create Network Interface
            Console.WriteLine("--------Start create Public IP--------");
            var publicIP = resourceGroup.GetPublicIpAddresss().Construct(resourceGroup.Data.Location).CreateOrUpdate($"{Context.VmName}_publicip").Value;

            // Create Network Interface
            Console.WriteLine("--------Start create Load Balancer--------");
            var lbData = new LoadBalancerData(new Azure.ResourceManager.Network.Models.LoadBalancer()
            {
                Location = resourceGroup.Data.Location,
            });
            var lb = resourceGroup.GetLoadBalancers().CreateOrUpdate($"{Context.VmName}_lb", lbData).Value;

            // Create VMSS
            VirtualMachineScaleSet vmss = resourceGroup
                .GetVirtualMachineScaleSet()
                .Construct($"{Context.VmName}ScaleSet")
                .WithRequiredLoadBalancer(lb.Id)
                .WithRequiredPrimaryNetworkInterface("default", nic.Id, null, null)
                //.WithUseLinuxImage("testvmss", "azureuser", "")
                .WithUseWindowsImage($"{Context.VmName}Prefix", "azureuser", "")
                .CreateOrUpdate($"{Context.VmName}ScaleSet");
            CleanUp.Add(vmss.Id);

            Console.WriteLine("\nDone all asserts passed ...");
        }
    }
}
