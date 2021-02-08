// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMImagesEdgeZoneTests : VMTestBase
    {
        private const string Edgezone = "MicrosoftRRDCLab1";
        private const string Location = "eastus2euap";
        private const string Publisher = "MicrosoftWindowsServer";
        private const string Offer = "WindowsServer";
        private const string Sku = "2016-Datacenter";

        [Fact]
        public void TestVMImageInEdgeZoneGet()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                string[] availableWindowsServerImageVersions = ListVMImagesInEdgeZone(
                    Location,
                    Edgezone,
                    Publisher,
                    Offer,
                    Sku).Select(t => t.Name).ToArray();

                var vmimage = GetVMImageInEdgeZone(
                    Location,
                    Edgezone,
                    Publisher,
                    Offer,
                    Sku,
                    availableWindowsServerImageVersions[0]);

                Assert.Equal(availableWindowsServerImageVersions[0], vmimage.Name);
                Assert.Equal(ComputeManagementTestUtilities.DefaultLocation, vmimage.Location, StringComparer.OrdinalIgnoreCase);
            }
        }

        [Fact]
        public void TestVMImageInEdgeZoneListNoFilter()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                var vmimages = ListVMImagesInEdgeZone(
                    Location,
                    Edgezone,
                    Publisher,
                    Offer,
                    Sku);

                Assert.True(vmimages.Count > 0);
            }
        }

        [Fact]
        public void TestVMImageInEdgeZoneListFilters()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                // Filter: top - Negative Test
                var vmimages = ListVMImagesInEdgeZone(
                    Location,
                    Edgezone,
                    Publisher,
                    Offer,
                    Sku,
                    top: 0);
                Assert.True(vmimages.Count == 0);

                // Filter: top - Positive Test
                vmimages = ListVMImagesInEdgeZone(
                    Location,
                    Edgezone,
                    Publisher,
                    Offer,
                    Sku,
                    top: 1);
                Assert.True(vmimages.Count == 1);

                // Filter: top - Positive Test
                vmimages = ListVMImagesInEdgeZone(
                    Location,
                    Edgezone,
                    Publisher,
                    Offer,
                    Sku,
                    top: 2);
                Assert.True(vmimages.Count == 2);

                // Filter: orderby - Positive Test
                vmimages = ListVMImagesInEdgeZone(
                    Location,
                    Edgezone,
                    Publisher,
                    Offer,
                    Sku,
                    orderby: "name desc");

                // Filter: orderby - Positive Test
                vmimages = ListVMImagesInEdgeZone(
                    Location,
                    Edgezone,
                    Publisher,
                    Offer,
                    Sku,
                    top: 2,
                    orderby: "name asc");
                Assert.True(vmimages.Count == 2);

                // Filter: top orderby - Positive Test
                vmimages = ListVMImagesInEdgeZone(
                    Location,
                    Edgezone,
                    Publisher,
                    Offer,
                    Sku,
                    top: 1,
                    orderby: "name desc");
                Assert.True(vmimages.Count == 1);

                // Filter: top orderby - Positive Test
                vmimages = ListVMImagesInEdgeZone(
                    Location,
                    ComputeManagementTestUtilities.DefaultLocation,
                    Publisher,
                    Offer,
                    Sku,
                    top: 1,
                    orderby: "name asc");
                Assert.True(vmimages.Count == 1);
            }
        }

        [Fact]
        public void TestVMImageInEdgeZoneListPublishers()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                var publishers = m_CrpClient.VirtualMachineImagesEdgeZone.ListPublishers(
                    Location,
                    Edgezone);

                Assert.True(publishers.Count > 0);
                Assert.True(publishers.Count(pub => pub.Name == "MicrosoftWindowsServer") != 0);
            }
        }

        [Fact]
        public void TestVMImageInEdgeZoneListOffers()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                var offers = m_CrpClient.VirtualMachineImagesEdgeZone.ListOffers(
                    Location,
                    Edgezone,
                    Publisher);

                Assert.True(offers.Count > 0);
                Assert.True(offers.Count(offer => offer.Name == "WindowsServer") != 0);
            }
        }

        [Fact]
        public void TestVMImageInEdgeZoneListSkus()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                var skus = m_CrpClient.VirtualMachineImagesEdgeZone.ListSkus(
                    Location,
                    Edgezone,
                    Publisher,
                    Offer);

                Assert.True(skus.Count > 0);
                Assert.True(skus.Count(sku => sku.Name == Sku) != 0);
            }
        }        
    }
}
