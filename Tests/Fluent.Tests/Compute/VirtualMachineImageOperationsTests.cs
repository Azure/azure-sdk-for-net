// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Fluent.Tests.Compute.VirtualMachine
{
    public class Image
    {
        [Fact]
        public void CanListAndGet()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                int maxListing = 20;
                int count = 0;
                var azure = TestHelper.CreateRollupClient();

                var images = azure.VirtualMachineImages.ListByRegion(Region.USEast);
                foreach (var image in images)
                {
                    count++;
                    if (count >= maxListing)
                    {
                        break;
                    }
                }
                var publishers = azure.VirtualMachineImages.Publishers.ListByRegion(Region.USEast);
                var canonicalPublisher = publishers.First(p => p.Name.Equals("Canonical", StringComparison.OrdinalIgnoreCase));
                Assert.NotNull(canonicalPublisher);

                IVirtualMachineImage firstVMImage = null;
                foreach (var offer in canonicalPublisher.Offers.List())
                {
                    foreach (var sku in offer.Skus.List())
                    {
                        foreach(var image in sku.Images.List())
                        {
                            firstVMImage = image;
                            break;
                        }
                        if (firstVMImage != null)
                        {
                            break;
                        }
                    }
                    if (firstVMImage != null)
                    {
                        break;
                    }
                }
                Assert.NotNull(firstVMImage);
                foreach(var dataDiskImage in firstVMImage.DataDiskImages.Values)
                {
                    Assert.NotNull(dataDiskImage);
                }

                var vmImage = azure.VirtualMachineImages.GetImage(Region.USEast, firstVMImage.PublisherName, firstVMImage.Offer, firstVMImage.Sku, firstVMImage.Version);
                Assert.NotNull(vmImage);

                vmImage = azure.VirtualMachineImages.GetImage(Region.USEast, firstVMImage.PublisherName, firstVMImage.Offer, firstVMImage.Sku, "latest");
                Assert.NotNull(vmImage);
            }
        }
    }
}
