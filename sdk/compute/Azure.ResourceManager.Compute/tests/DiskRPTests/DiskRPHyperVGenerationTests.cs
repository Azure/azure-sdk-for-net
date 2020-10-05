// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.DiskRPTests
{
    public class DiskRPHyperVGenerationTests : DiskRPTestsBase
    {
        public DiskRPHyperVGenerationTests(bool isAsync)
        : base(isAsync)
        {
        }
        private static string DiskRPLocation = "westcentralus";

        [Test]
        public async Task DiskHyperVGeneration1PositiveTest()
        {
            EnsureClientsInitialized(DefaultLocation);

            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            Disk disk = await GenerateDefaultDisk(DiskCreateOption.Empty.ToString(), rgName, 10);
            disk.HyperVGeneration = HyperVGeneration.V1;
            disk.Location = DiskRPLocation;
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(DiskRPLocation));
            //put disk
            await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk));
            Disk diskOut = await DisksOperations.GetAsync(rgName, diskName);
            Validate(disk, diskOut, disk.Location);
            Assert.AreEqual(disk.HyperVGeneration, diskOut.HyperVGeneration);
            await WaitForCompletionAsync(await DisksOperations.StartDeleteAsync(rgName, diskName));
        }

        [Test]
        public async Task DiskHyperVGeneration2PositiveTest()
        {
            EnsureClientsInitialized(DefaultLocation);

            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            Disk disk = await GenerateDefaultDisk(DiskCreateOption.Empty.ToString(), rgName, 10);
            disk.HyperVGeneration = HyperVGeneration.V2;
            disk.Location = DiskRPLocation;
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(DiskRPLocation));
            //put disk
            await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk));
            Disk diskOut = await DisksOperations.GetAsync(rgName, diskName);

            Validate(disk, diskOut, disk.Location);
            Assert.AreEqual(disk.HyperVGeneration, diskOut.HyperVGeneration);
            await WaitForCompletionAsync(await DisksOperations.StartDeleteAsync(rgName, diskName));
        }

        [Test]
        public async Task DiskHyperVGenerationOmittedTest()
        {
            EnsureClientsInitialized(DefaultLocation);
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            Disk disk = await GenerateDefaultDisk(DiskCreateOption.Empty.ToString(), rgName, 10);
            disk.Location = DiskRPLocation;
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(DiskRPLocation));
            //put disk
            await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk));
            Disk diskOut = await DisksOperations.GetAsync(rgName, diskName);

            Validate(disk, diskOut, disk.Location);
            Assert.AreEqual(disk.HyperVGeneration, diskOut.HyperVGeneration);
            await WaitForCompletionAsync(await DisksOperations.StartDeleteAsync(rgName, diskName));
        }
    }
}
