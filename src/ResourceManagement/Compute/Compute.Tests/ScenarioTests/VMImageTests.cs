//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Compute.Tests
{
    public class VMImagesTests
    {
        private static readonly string[] AvailableWindowsServerImageVersions = new string[] { "4.0.201505", "4.0.201504", "4.0.201503" };

        private static readonly VirtualMachineImageGetParameters parameters = new VirtualMachineImageGetParameters()
        {
            Location = ComputeManagementTestUtilities.DefaultLocation,
            PublisherName = "MicrosoftWindowsServer",
            Offer = "WindowsServer",
            Skus = "2012-R2-Datacenter",
            Version = AvailableWindowsServerImageVersions[0]
        };

        private static readonly VirtualMachineImageListParameters listParameters = new VirtualMachineImageListParameters()
        {
            Location = ComputeManagementTestUtilities.DefaultLocation,
            PublisherName = "MicrosoftWindowsServer",
            Offer = "WindowsServer",
            Skus = "2012-R2-Datacenter",
        };

        //[Not used here. What is this for?]
        private static readonly VirtualMachineImage vmimage_v100 = new VirtualMachineImage()
        {
            Id = "/subscriptions/84fffc2f-5d77-449a-bc7f-58c363f2a6b9/providers/Microsoft.Compute/locations/westus/publishers/Microsoft.Windows/artifacttypes/vmimage/offers/WindowsServer2012/skus/Enterprise/versions/1.0.0",
            Name = "1.0.0",
            Location = "westus",
            PurchasePlan = new PurchasePlan()
            {
                Name = "name",
                Product = "product",
                Publisher = "publisher",
            },
            OSDiskImage = new OSDiskImage()
            {
                OperatingSystem = "Linux"
            },
            DataDiskImages = new []
            {
                new DataDiskImage(){Lun = 123456789}, 
            }
        };

        private static readonly VirtualMachineImage vmimage_v110 = new VirtualMachineImage()
        {
            Id = "/subscriptions/84fffc2f-5d77-449a-bc7f-58c363f2a6b9/providers/Microsoft.Compute/locations/westus/publishers/Microsoft.Windows/artifacttypes/vmimage/offers/WindowsServer2012/skus/Enterprise/versions/1.1.0",
            Name = "1.1.0",
            Location = "westus",
            PurchasePlan = new PurchasePlan()
            {
                Name = "name",
                Product = "product",
                Publisher = "publisher",
            },
            OSDiskImage = new OSDiskImage()
            {
                OperatingSystem = "Linux"
            },
            DataDiskImages = new[]
            {
                new DataDiskImage(){Lun = 123456789}, 
            }
        };

        [Fact]
        public void TestVMImageGet()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient();

                var vmimage = _pirClient.VirtualMachineImages.Get(parameters);

                Assert.Equal(parameters.Version, vmimage.VirtualMachineImage.Name);
                Assert.Equal(parameters.Location, vmimage.VirtualMachineImage.Location, StringComparer.OrdinalIgnoreCase);

                // FIXME: This doesn't work with a real Windows Server images, which is what's in the query parameters.
                // Bug 4196378
                /*
                Assert.True(vmimage.VirtualMachineImage.PurchasePlan.Name == "name");
                Assert.True(vmimage.VirtualMachineImage.PurchasePlan.Publisher == "publisher");
                Assert.True(vmimage.VirtualMachineImage.PurchasePlan.Product == "product");
                */

                Assert.True(vmimage.VirtualMachineImage.OSDiskImage.OperatingSystem == "Windows");

                //Assert.True(vmimage.VirtualMachineImage.DataDiskImages.Count(ddi => ddi.Lun == 123456789) != 0);
            }
        }

        [Fact]
        public void TestVMImageListNoFilter()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient();

                var vmimages = _pirClient.VirtualMachineImages.List(listParameters);

                Assert.True(vmimages.Resources.Count > 0);
                Assert.True(vmimages.Resources.Count(vmi => vmi.Name == AvailableWindowsServerImageVersions[0]) != 0);
                Assert.True(vmimages.Resources.Count(vmi => vmi.Name == AvailableWindowsServerImageVersions[1]) != 0);
            }
        }

        [Fact]
        public void TestVMImageListFilters()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient();

                VirtualMachineImageListParameters listParametersWithFilter = new VirtualMachineImageListParameters()
                {
                    Location = listParameters.Location,
                    PublisherName = listParameters.PublisherName,
                    Offer = listParameters.Offer,
                    Skus = listParameters.Skus,
                };

                // Filter: top - Negative Test
                listParametersWithFilter.FilterExpression = "$top=0";
                var vmimages = _pirClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.True(vmimages.Resources.Count == 0);

                // Filter: top - Positive Test
                listParametersWithFilter.FilterExpression = "$top=1";
                vmimages = _pirClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.True(vmimages.Resources.Count == 1);

                // Filter: top - Positive Test
                listParametersWithFilter.FilterExpression = "$top=2";
                vmimages = _pirClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.True(vmimages.Resources.Count == 2);
                Assert.True(vmimages.Resources.Count(vmi => vmi.Name == AvailableWindowsServerImageVersions[1]) != 0);

                // Filter: orderby - Positive Test
                listParametersWithFilter.FilterExpression = "$orderby=name desc";
                vmimages = _pirClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.Equal(AvailableWindowsServerImageVersions.Length, vmimages.Resources.Count);
                for (int i = 0; i < AvailableWindowsServerImageVersions.Length; i++)
                {
                    Assert.Equal(AvailableWindowsServerImageVersions[i], vmimages.Resources[i].Name);
                }

                // Filter: orderby - Positive Test
                listParametersWithFilter.FilterExpression = "$top=2&$orderby=name asc";
                vmimages = _pirClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.True(vmimages.Resources.Count == 2);
                Assert.True(vmimages.Resources[0].Name == AvailableWindowsServerImageVersions.Last());
                Assert.True(vmimages.Resources[1].Name == AvailableWindowsServerImageVersions.Reverse().Skip(1).First());

                // Filter: top orderby - Positive Test
                listParametersWithFilter.FilterExpression = "$top=1&$orderby=name desc";
                vmimages = _pirClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.True(vmimages.Resources.Count == 1);
                Assert.True(vmimages.Resources[0].Name == AvailableWindowsServerImageVersions[0]);

                // Filter: top orderby - Positive Test
                listParametersWithFilter.FilterExpression = "$top=1&$orderby=name asc";
                vmimages = _pirClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.True(vmimages.Resources.Count == 1);
                Assert.True(vmimages.Resources[0].Name == AvailableWindowsServerImageVersions.Last());
            }
        }

        [Fact]
        public void TestVMImageListPublishers()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient();

                var publishers = _pirClient.VirtualMachineImages.ListPublishers(parameters);

                Assert.True(publishers.Resources.Count > 0);
                Assert.True(publishers.Resources.Count(pub => pub.Name == parameters.PublisherName) != 0);
            }
        }

        [Fact]
        public void TestVMImageListOffers()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient();

                var offers = _pirClient.VirtualMachineImages.ListOffers(parameters);

                Assert.True(offers.Resources.Count > 0);
                Assert.True(offers.Resources.Count(offer => offer.Name == parameters.Offer) != 0);
            }
        }

        [Fact]
        public void TestVMImageListSkus()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                ComputeManagementClient _pirClient = ComputeManagementTestUtilities.GetComputeManagementClient();

                var skus = _pirClient.VirtualMachineImages.ListSkus(parameters);

                Assert.True(skus.Resources.Count > 0);
                Assert.True(skus.Resources.Count(sku => sku.Name == parameters.Skus) != 0);
            }
        }
    }
}
