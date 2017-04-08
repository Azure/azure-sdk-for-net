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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
        public void TestVMImageListNoFilter()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var query = new Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineImageResource>();

                // Filter: top - Negative Test
                query.Top = 0;
                var vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    query);
                Assert.True(vmimages.Count == 0);

                // Filter: top - Positive Test
                query.Top = 1;
                vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    query);
                Assert.True(vmimages.Count == 1);

                // Filter: top - Positive Test
                query.Top = 2;
                vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    query);
                Assert.True(vmimages.Count == 2);

                // Filter: orderby - Positive Test
                query.Top = null;
                query.OrderBy = "name desc";
                vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    query);

                // Filter: orderby - Positive Test
                query.Top = 2;
                query.OrderBy = "name asc";
                vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    query);
                Assert.True(vmimages.Count == 2);

                // Filter: top orderby - Positive Test
                query.Top = 1;
                query.OrderBy = "name desc";
                vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    query);
                Assert.True(vmimages.Count == 1);

                // Filter: top orderby - Positive Test
                query.Top = 1;
                query.OrderBy = "name asc";
                vmimages = _pirClient.VirtualMachineImages.List(
                    ComputeManagementTestUtilities.DefaultLocation,
                    "MicrosoftWindowsServer",
                    "WindowsServer",
                    "2012-R2-Datacenter",
                    query);
                Assert.True(vmimages.Count == 1);
            }
        }

        [Fact]
        public void TestVMImageListPublishers()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
