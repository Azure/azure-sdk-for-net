using System;
using Microsoft.Azure.Management.StoragePool;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Compute.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroup = Microsoft.Azure.Management.ResourceManager.Models.ResourceGroup;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.StoragePool.Models;
using ManagedDisk = Microsoft.Azure.Management.Compute.Models.Disk;
using Disk = Microsoft.Azure.Management.StoragePool.Models.Disk;
using DiskPoolSku = Microsoft.Azure.Management.StoragePool.Models.Sku;

namespace StoragePool.Tests
{
    public class IscsiTargetTests : TestBase
    {
        [Fact]
        public void IscsiTargetCrud()
        {
            using var context = MockContext.Start(this.GetType());
            string resourceGroupName = TestUtilities.GenerateName("sdk-itcrud-rg");
            string diskPoolName = TestUtilities.GenerateName("sdk-diskpool");
            string iscsiTargetName = TestUtilities.GenerateName("target01");
            string diskName = TestUtilities.GenerateName("sdk-test-disk");
            string location = "eastus2euap";

            Console.WriteLine(diskPoolName);
            Console.WriteLine(iscsiTargetName);
            Console.WriteLine(resourceGroupName);
            Console.WriteLine(location);

            CreateResourceGroup(context, location, resourceGroupName);

            try
            {
                using var testBase = new StoragePoolTestBase(context);
                var client = testBase.StoragePoolClient;

                var vnetName = "sdk-vnet";
                var subnetName = "sdk-subnet";
                var diskName1 = "sdk-disk";
                var diskName2 = "sdk-disk-2";
                var availabilityZone = "2";

                // create vnet and subnet
                var networkClient = context.GetServiceClient<NetworkManagementClient>();
                var vnet = new VirtualNetwork()
                {
                    Location = location,
                    AddressSpace = new AddressSpace() { AddressPrefixes = new[] { "10.0.0.0/16" } },
                    Subnets = new[]
                    {
                    new Subnet()
                        {
                            Name = subnetName,
                            AddressPrefix = "10.0.0.0/24",
                            Delegations = new Delegation[1]
                            {
                                new Delegation()
                                {
                                    Name = "diskpool-delegation",
                                    ServiceName = "Microsoft.StoragePool/diskPools",
                                },
                            },
                        },
                    },
                };
                networkClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
                var subnet = networkClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

                var computeClient = context.GetServiceClient<ComputeManagementClient>();

                // create disk 1
                var sku = new DiskSku();
                sku.Name = DiskStorageAccountTypes.PremiumLRS;
                var disk1 = new ManagedDisk()
                {
                    Location = location,
                    Sku = sku,
                    Zones = new[] { availabilityZone },
                    DiskSizeGB = 256,
                    CreationData = new CreationData(DiskCreateOption.Empty),
                    MaxShares = 2,
                };
                computeClient.Disks.CreateOrUpdate(resourceGroupName, diskName1, disk1);
                disk1 = computeClient.Disks.Get(resourceGroupName, diskName1);

                var disk2 = new ManagedDisk()
                {
                    Location = location,
                    Sku = sku,
                    Zones = new[] { availabilityZone },
                    DiskSizeGB = 256,
                    CreationData = new CreationData(DiskCreateOption.Empty),
                    MaxShares = 2,
                };
                computeClient.Disks.CreateOrUpdate(resourceGroupName, diskName2, disk2);
                disk2 = computeClient.Disks.Get(resourceGroupName, diskName2);

                // create disk pool
                var disks = new Disk[] { new Disk(disk1.Id), new Disk(disk2.Id) };
                var diskPoolSku = new DiskPoolSku("Standard", "Standard");
                var diskPool = new DiskPoolCreate(diskPoolSku, subnet.Id, location, new[] { availabilityZone }, disks);
                client.DiskPools.CreateOrUpdate(resourceGroupName, diskPoolName, diskPool);

                // assert that create succeeded
                var createdDiskPool = client.DiskPools.Get(resourceGroupName, diskPoolName);
                Assert.NotNull(createdDiskPool);
                Assert.Equal("Succeeded", createdDiskPool.ProvisioningState);

                // create iscsi target
                var luns = new IscsiLun[] { new IscsiLun("lun1", disk1.Id)};
                var iscsiTarget = new IscsiTargetCreate(IscsiTargetAclMode.Dynamic, iscsiTargetName);
                iscsiTarget.Luns = luns;
                client.IscsiTargets.CreateOrUpdate(resourceGroupName, diskPoolName, iscsiTargetName, iscsiTarget);

                var createdIscsiTarget = client.IscsiTargets.Get(resourceGroupName, diskPoolName, iscsiTargetName);
                Assert.NotNull(createdIscsiTarget);
                Assert.Equal("Succeeded", createdIscsiTarget.ProvisioningState);

                luns = new IscsiLun[] { new IscsiLun("lun1", disk1.Id), new IscsiLun("lun2", disk2.Id)};
                var iscsiTargetUpdate = new IscsiTargetCreate();
                iscsiTargetUpdate.Luns = luns;

                client.IscsiTargets.CreateOrUpdate(resourceGroupName, diskPoolName, iscsiTargetName, iscsiTargetUpdate);
                var updatedIscsiTarget = client.IscsiTargets.Get(resourceGroupName, diskPoolName, iscsiTargetName);
                Assert.NotNull(updatedIscsiTarget);
                Assert.Equal("Succeeded", updatedIscsiTarget.ProvisioningState);

                // delete iscsi target
                client.IscsiTargets.Delete(resourceGroupName, diskPoolName, iscsiTargetName);

                // delete disk pool
                client.DiskPools.Delete(resourceGroupName, diskPoolName);
            }
            finally
            {
                DeleteResourceGroup(context, resourceGroupName);
            }
        }

        private ResourceGroup CreateResourceGroup(MockContext context, string location, string name)
        {
            var client = context.GetServiceClient<ResourceManagementClient>();
            return client.ResourceGroups.CreateOrUpdate(
                name,
                new ResourceGroup
                {
                    Location = location
                });
        }

        private void DeleteResourceGroup(MockContext context, string name)
        {
            var client = context.GetServiceClient<ResourceManagementClient>();
            client.ResourceGroups.Delete(name);
        }
    }
}
