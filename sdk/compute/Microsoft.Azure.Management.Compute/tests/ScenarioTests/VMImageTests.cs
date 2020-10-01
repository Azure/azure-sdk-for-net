// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class VMImagesTests
    {
        [Fact]
        public void TestVMImageGet()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                string[] availableWindowsServerImageVersions = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter").Select(t => t.Name).ToArray();

                var vmimage = _pirClient.VirtualMachineImages.Get(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer", 
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    availableWindowsServerImageVersions[0]);

                Assert.Equal(availableWindowsServerImageVersions[0], vmimage.Name);
                Assert.Equal(ComputeManagementTestUtilities.DefaultLocation, vmimage.Location, StringComparer.OrdinalIgnoreCase);

                // FIXME: This doesn't work with a real Windows Server images, which is what's in the query parameters.
                // Bug 4196378
                /*
                Assert.True(vmimage.VirtualMachineImage.PurchasePlan.Name == "name");
                Assert.True(vmimage.VirtualMachineImage.PurchasePlan.Publisher == "publisher");
                Assert.True(vmimage.VirtualMachineImage.PurchasePlan.Product == "product");
                */

                Assert.Equal(OperatingSystemTypes.Windows, vmimage.OsDiskImage.OperatingSystem);

                //Assert.True(vmimage.VirtualMachineImage.DataDiskImages.Count(ddi => ddi.Lun == 123456789) != 0);
            }
        }

        [Fact]
        public void TestVMImageAutomaticOSUpgradeProperties()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Validate if images supporting automatic OS upgrades return
                // AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported = true in GET VMImageVesion call
                string imagePublisher = "MicrosoftWindowsServer";
                string imageOffer = "WindowsServer";
                string imageSku = "2016-Datacenter";
                string[] availableWindowsServerImageVersions =_pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation, imagePublisher, imageOffer, imageSku).Select(t => t.Name).ToArray();

                string firstVersion = availableWindowsServerImageVersions.First();
                string lastVersion = null;
                if (availableWindowsServerImageVersions.Length >= 2)
                {
                    lastVersion = availableWindowsServerImageVersions.Last();
                }

                var vmimage = _pirClient.VirtualMachineImages.Get(
                    ComputeManagementTestUtilities.DefaultLocation, imagePublisher, imageOffer, imageSku, firstVersion);
                Assert.True(vmimage.AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported);

                if (!string.IsNullOrEmpty(lastVersion))
                {
                    vmimage = _pirClient.VirtualMachineImages.Get(
                        ComputeManagementTestUtilities.DefaultLocation, imagePublisher, imageOffer, imageSku, lastVersion);
                    Assert.True(vmimage.AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported);
                }

                // Validate if image not allowlisted to support automatic OS upgrades, return
                // AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported = false in GET VMImageVesion call
                imagePublisher = "Canonical";
                imageOffer = "UbuntuServer";
                imageSku = _pirClient.VirtualMachineImages.ListSkus(ComputeManagementTestUtilities.DefaultLocation, imagePublisher, imageOffer).FirstOrDefault().Name;
                string[] availableUbuntuImageVersions = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation, imagePublisher, imageOffer, imageSku).Select(t => t.Name).ToArray();

                firstVersion = availableUbuntuImageVersions.First();
                lastVersion = null;
                if (availableUbuntuImageVersions.Length >= 2)
                {
                    lastVersion = availableUbuntuImageVersions.Last();
                }

                vmimage = _pirClient.VirtualMachineImages.Get(
                    ComputeManagementTestUtilities.DefaultLocation, imagePublisher, imageOffer, imageSku, firstVersion);
                Assert.False(vmimage.AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported);

                if (!string.IsNullOrEmpty(lastVersion))
                {
                    vmimage = _pirClient.VirtualMachineImages.Get(
                        ComputeManagementTestUtilities.DefaultLocation, imagePublisher, imageOffer, imageSku, lastVersion);
                    Assert.False(vmimage.AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported);
                }
            }
        }

        [Fact]
        public void TestVMImageListNoFilter()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation, 
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter");

                Assert.True(vmimages.Count > 0);
                //Assert.True(vmimages.Count(vmi => vmi.Name == AvailableWindowsServerImageVersions[0]) != 0);
                //Assert.True(vmimages.Count(vmi => vmi.Name == AvailableWindowsServerImageVersions[1]) != 0);
            }
        }

        [Fact]
        public void TestVMImageListFilters()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Filter: top - Negative Test
                var vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    top: 0);
                Assert.True(vmimages.Count == 0);

                // Filter: top - Positive Test
                vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    top: 1);
                Assert.True(vmimages.Count == 1);

                // Filter: top - Positive Test
                vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    top: 2);
                Assert.True(vmimages.Count == 2);

                // Filter: orderby - Positive Test
                vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    orderby: "name desc");

                // Filter: orderby - Positive Test
                vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    top: 2,
                    orderby: "name asc");
                Assert.True(vmimages.Count == 2);

                // Filter: top orderby - Positive Test
                vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    top: 1,
                    orderby: "name desc");
                Assert.True(vmimages.Count == 1);

                // Filter: top orderby - Positive Test
                vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    top: 1,
                    orderby: "name asc");
                Assert.True(vmimages.Count == 1);
            }
        }

        [Fact]
        public void TestVMImageListPublishers()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {

                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var publishers = _pirClient.VirtualMachineImages.ListPublishers(
                    ComputeManagementTestUtilities.DefaultLocation);

                Assert.True(publishers.Count > 0);
                Assert.True(publishers.Count(pub => pub.Name == "MicrosoftWindowsServer") != 0);
            }
        }

        [Fact]
        public void TestVMImageListOffers()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var offers = _pirClient.VirtualMachineImages.ListOffers(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer");

                Assert.True(offers.Count > 0);
                Assert.True(offers.Count(offer => offer.Name == "WindowsServer") != 0);
            }
        }

        [Fact]
        public void TestVMImageListSkus()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {

                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var skus = _pirClient.VirtualMachineImages.ListSkus(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer");

                Assert.True(skus.Count > 0);
                Assert.True(skus.Count(sku => sku.Name == "2012-R2-Datacenter") != 0);
            }
        }
    }
}

