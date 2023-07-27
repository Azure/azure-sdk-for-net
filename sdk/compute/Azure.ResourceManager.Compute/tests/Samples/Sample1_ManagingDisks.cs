// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_Disks_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
#endregion Snippet:Manage_Disks_Namespaces

namespace Azure.ResourceManager.Compute.Tests.Samples
{
    public class Sample1_ManagingDisks
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDisk()
        {
            #region Snippet:Managing_Disks_CreateADisk
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            // first we need to get the resource group
            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            // Now we get the disk collection from the resource group
            ManagedDiskCollection diskCollection = resourceGroup.GetManagedDisks();
            // Use the same location as the resource group
            string diskName = "myDisk";
            ManagedDiskData input = new ManagedDiskData(resourceGroup.Data.Location)
            {
                Sku = new DiskSku()
                {
                    Name = DiskStorageAccountType.StandardLrs
                },
                CreationData = new DiskCreationData(DiskCreateOption.Empty),
                DiskSizeGB = 1,
            };
            ArmOperation<ManagedDiskResource> lro = await diskCollection.CreateOrUpdateAsync(WaitUntil.Completed, diskName, input);
            ManagedDiskResource disk = lro.Value;
            #endregion Snippet:Managing_Disks_CreateADisk
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListDisks()
        {
            #region Snippet:Managing_Disks_ListAllDisks
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            // first we need to get the resource group
            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            // Now we get the disk collection from the resource group
            ManagedDiskCollection diskCollection = resourceGroup.GetManagedDisks();
            // With GetAllAsync(), we can get a list of the disks
            await foreach (ManagedDiskResource disk in diskCollection.GetAllAsync())
            {
                Console.WriteLine(disk.Data.Name);
            }
            #endregion Snippet:Managing_Disks_ListAllDisks
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteDisk()
        {
            #region Snippet:Managing_Disks_DeleteDisk
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            // first we need to get the resource group
            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            // Now we get the disk collection from the resource group
            ManagedDiskCollection diskCollection = resourceGroup.GetManagedDisks();
            string diskName = "myDisk";
            ManagedDiskResource disk = await diskCollection.GetAsync(diskName);
            await disk.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Managing_Disks_DeleteDisk
        }
    }
}
