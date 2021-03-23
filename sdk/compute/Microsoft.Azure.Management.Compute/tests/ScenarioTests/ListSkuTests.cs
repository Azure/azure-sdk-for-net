// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class ListSkuTests
    {
        [Fact]
        public void TestListSkus()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var computeClient = ComputeManagementTestUtilities.GetComputeManagementClient(context,
                    new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                IPage<ResourceSku> skus = computeClient.ResourceSkus.List();
                Assert.True(skus.Any(), "Assert that the array of skus has at least 1 member.");
                Assert.True(skus.Any(sku => sku.ResourceType == "availabilitySets"), "Assert that the sku list at least contains" +
                                                                                     "one availability set.");
                Assert.True(skus.Any(sku => sku.ResourceType == "virtualMachines"), "Assert that the sku list at least contains" +
                                                                                    "one virtual machine.");
                Assert.True(skus.Any(sku => sku.LocationInfo != null), "Assert that the sku list has non null location info in it.");
                Assert.True(skus.All(sku => sku.LocationInfo.Count == 1), "There should be exactly one location info per entry.");
                Assert.True(skus.Any(sku => sku.LocationInfo[0].Location.Equals("westus", StringComparison.Ordinal)), "Assert that it has entry for one of the CRP regions (randomly picked).");         

                // EastUS2EUAP is one of the regions where UltraSSD is enabled, hence verifying that CRP and ARM are returning correct
                // properties related to UltraSSD in the SKUs API
                var vmSkusInEastUS2Euap = skus.Where(
                    s => s.Locations[0].Equals("eastus2euap", StringComparison.OrdinalIgnoreCase) && s.ResourceType == "virtualMachines").ToList();

                var ultraSSDSupportingSku = vmSkusInEastUS2Euap.First(s => s.Name == "Standard_B2s");
                var nonUltraSSDSupportingSku = vmSkusInEastUS2Euap.First(s => s.Name == "Standard_A7");

                Assert.NotNull(ultraSSDSupportingSku.LocationInfo);
                Assert.Equal(1, ultraSSDSupportingSku.LocationInfo.Count);
                Assert.NotNull(ultraSSDSupportingSku.LocationInfo[0].ZoneDetails);
                Assert.Equal(1, ultraSSDSupportingSku.LocationInfo[0].ZoneDetails.Count);
                Assert.NotNull(ultraSSDSupportingSku.LocationInfo[0].ZoneDetails[0].Name);
                Assert.NotNull(ultraSSDSupportingSku.LocationInfo[0].ZoneDetails[0].Capabilities);
                Assert.Equal(1, ultraSSDSupportingSku.LocationInfo[0].ZoneDetails[0].Capabilities.Count);
                Assert.Equal("UltraSSDAvailable", ultraSSDSupportingSku.LocationInfo[0].ZoneDetails[0].Capabilities[0].Name);
                Assert.Equal("True", ultraSSDSupportingSku.LocationInfo[0].ZoneDetails[0].Capabilities[0].Value);

                Assert.NotNull(nonUltraSSDSupportingSku.LocationInfo);
                // ZoneDetails should not be set for a SKU which does not support ultraSSD. This is because we do not have any
                // other zonal capability currently.
                //Assert.Null(nonUltraSSDSupportingSku.LocationInfo[0].ZoneDetails);
                Assert.Equal(0, nonUltraSSDSupportingSku.LocationInfo[0].ZoneDetails.Count);
            }
        }
    }
}
