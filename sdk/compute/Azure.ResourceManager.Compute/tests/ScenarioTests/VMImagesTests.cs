// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class VMImagesTests:ComputeClientBase
    {
        public VMImagesTests(bool isAsync)
         : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task TestVMImageGet()
        {
            string[] availableWindowsServerImageVersions = (await VirtualMachineImagesOperations.ListAsync(
                DefaultLocation,
                "MicrosoftWindowsServer",
                "WindowsServer",
                "2012-R2-Datacenter")).Value.Select(t => t.Name).ToArray();

            var vmimage = await VirtualMachineImagesOperations.GetAsync(
                DefaultLocation,
                "MicrosoftWindowsServer",
                "WindowsServer",
                "2012-R2-Datacenter",
                availableWindowsServerImageVersions[0]);

            Assert.AreEqual(availableWindowsServerImageVersions[0], vmimage.Value.Name);
            //Assert.AreEqual("southeastasia", vmimage.Value.Location);
            Assert.AreEqual(DefaultLocation, vmimage.Value.Location);

            // FIXME: This doesn't work with a real Windows Server images, which is what's in the query parameters.
            // Bug 4196378
            /*
            Assert.True(vmimage.VirtualMachineImage.PurchasePlan.Name == "name");
            Assert.True(vmimage.VirtualMachineImage.PurchasePlan.Publisher == "publisher");
            Assert.True(vmimage.VirtualMachineImage.PurchasePlan.Product == "product");
            */
            Assert.AreEqual(OperatingSystemTypes.Windows, vmimage.Value.OsDiskImage.OperatingSystem);
            //Assert.True(vmimage.VirtualMachineImage.DataDiskImages.Count(ddi => ddi.Lun == 123456789) != 0);
        }

        [Test]
        public async Task TestVMImageAutomaticOSUpgradeProperties()
        {
            // Validate if images supporting automatic OS upgrades return
            // AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported = true in GET VMImageVesion call
            string imagePublisher = "MicrosoftWindowsServer";
            string imageOffer = "WindowsServer";
            string imageSku = "2016-Datacenter";
            string[] availableWindowsServerImageVersions = (await VirtualMachineImagesOperations.ListAsync(
                DefaultLocation, imagePublisher, imageOffer, imageSku)).Value.Select(t => t.Name).ToArray();

            string firstVersion = availableWindowsServerImageVersions.First();
            string lastVersion = null;
            if (availableWindowsServerImageVersions.Length >= 2)
            {
                lastVersion = availableWindowsServerImageVersions.Last();
            }

            var vmimage = await VirtualMachineImagesOperations.GetAsync(
                DefaultLocation, imagePublisher, imageOffer, imageSku, firstVersion);
            Assert.True(vmimage.Value.AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported);

            if (!string.IsNullOrEmpty(lastVersion))
            {
                vmimage = await VirtualMachineImagesOperations.GetAsync(
                    DefaultLocation, imagePublisher, imageOffer, imageSku, lastVersion);
                Assert.True(vmimage.Value.AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported);
            }

            // Validate if image not whitelisted to support automatic OS upgrades, return
            // AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported = false in GET VMImageVesion call
            imagePublisher = "Canonical";
            imageOffer = "UbuntuServer";
            imageSku = (await VirtualMachineImagesOperations.ListSkusAsync(DefaultLocation, imagePublisher, imageOffer)).Value.FirstOrDefault().Name;
            string[] availableUbuntuImageVersions = (await VirtualMachineImagesOperations.ListAsync(
                DefaultLocation, imagePublisher, imageOffer, imageSku)).Value.Select(t => t.Name).ToArray();

            firstVersion = availableUbuntuImageVersions.First();
            lastVersion = null;
            if (availableUbuntuImageVersions.Length >= 2)
            {
                lastVersion = availableUbuntuImageVersions.Last();
            }

            vmimage = await VirtualMachineImagesOperations.GetAsync(
                DefaultLocation, imagePublisher, imageOffer, imageSku, firstVersion);
            Assert.False(vmimage.Value.AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported);

            if (!string.IsNullOrEmpty(lastVersion))
            {
                vmimage = await VirtualMachineImagesOperations.GetAsync(
                    DefaultLocation, imagePublisher, imageOffer, imageSku, lastVersion);
                Assert.False(vmimage.Value.AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported);
            }
        }

        [Test]
        public async Task TestVMImageListNoFilter()
        {
            var vmimages = await VirtualMachineImagesOperations.ListAsync(
                DefaultLocation,
                "MicrosoftWindowsServer",
                "WindowsServer",
                "2012-R2-Datacenter");

            Assert.True(vmimages.Value.Count > 0);
            //Assert.True(vmimages.Count(vmi => vmi.Name == AvailableWindowsServerImageVersions[0]) != 0);
            //Assert.True(vmimages.Count(vmi => vmi.Name == AvailableWindowsServerImageVersions[1]) != 0);
        }

        [Test]
        public async Task TestVMImageListFilters()
        {
            // Filter: top - Negative Test
            var vmimages = await VirtualMachineImagesOperations.ListAsync(
                DefaultLocation,
                "MicrosoftWindowsServer",
                "WindowsServer",
                "2012-R2-Datacenter",
                top: 0);
            Assert.True(vmimages.Value.Count == 0);

            // Filter: top - Positive Test
            vmimages = await VirtualMachineImagesOperations.ListAsync(
                DefaultLocation,
                "MicrosoftWindowsServer",
                "WindowsServer",
                "2012-R2-Datacenter",
                top: 1);
            Assert.True(vmimages.Value.Count == 1);

            // Filter: top - Positive Test
            vmimages = await VirtualMachineImagesOperations.ListAsync(
                DefaultLocation,
                "MicrosoftWindowsServer",
                "WindowsServer",
                "2012-R2-Datacenter",
                top: 2);
            Assert.True(vmimages.Value.Count == 2);

            // Filter: orderby - Positive Test
            vmimages = await VirtualMachineImagesOperations.ListAsync(
                DefaultLocation,
                "MicrosoftWindowsServer",
                "WindowsServer",
                "2012-R2-Datacenter",
                orderby: "name desc");

            // Filter: orderby - Positive Test
            vmimages = await VirtualMachineImagesOperations.ListAsync(
                DefaultLocation,
                "MicrosoftWindowsServer",
                "WindowsServer",
                "2012-R2-Datacenter",
                top: 2,
                orderby: "name asc");
            Assert.True(vmimages.Value.Count == 2);

            // Filter: top orderby - Positive Test
            vmimages = await VirtualMachineImagesOperations.ListAsync(
                DefaultLocation,
                "MicrosoftWindowsServer",
                "WindowsServer",
                "2012-R2-Datacenter",
                top: 1,
                orderby: "name desc");
            Assert.True(vmimages.Value.Count == 1);

            // Filter: top orderby - Positive Test
            vmimages = await VirtualMachineImagesOperations.ListAsync(
                DefaultLocation,
                "MicrosoftWindowsServer",
                "WindowsServer",
                "2012-R2-Datacenter",
                top: 1,
                orderby: "name asc");
            Assert.True(vmimages.Value.Count == 1);
        }

        [Test]
        public async Task TestVMImageListPublishers()
        {
            var publishers = await VirtualMachineImagesOperations.ListPublishersAsync(
                DefaultLocation);

            Assert.True(publishers.Value.Count > 0);
            Assert.True(publishers.Value.Count(pub => pub.Name == "MicrosoftWindowsServer") != 0);
        }

        [Test]
        public async Task TestVMImageListOffers()
        {
            var offers = await VirtualMachineImagesOperations.ListOffersAsync(
                DefaultLocation,
                "MicrosoftWindowsServer");

            Assert.True(offers.Value.Count > 0);
            Assert.True(offers.Value.Count(offer => offer.Name == "WindowsServer") != 0);
        }

        [Test]
        public async Task TestVMImageListSkus()
        {
            var skus = await VirtualMachineImagesOperations.ListSkusAsync(
                DefaultLocation,
                "MicrosoftWindowsServer",
                "WindowsServer");

            Assert.True(skus.Value.Count > 0);
            Assert.True(skus.Value.Count(sku => sku.Name == "2012-R2-Datacenter") != 0);
        }
    }
}
