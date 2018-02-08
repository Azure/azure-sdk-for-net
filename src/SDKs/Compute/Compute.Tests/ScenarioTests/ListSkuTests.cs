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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
            }
        }
    }
}