// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;
using System.Threading;
using System.Linq;

namespace Microsoft.Azure.Management.Quantum.Tests
{
    public class OfferingOperationTests : QuantumManagementTestBase
    {
        [Fact]
        public void TestListOfferings()
        {
            TestInitialize();

            var firstPage = QuantumClient.Offerings.List(CommonData.Location);
            var offerings = QuantumManagementTestUtilities.ListResources(firstPage, QuantumClient.Offerings.ListNext);
            Assert.True(offerings.Count >= 1);
            var microsoftQIO = offerings.FirstOrDefault((offering) => "Microsoft".Equals(offering.Id));
            Assert.NotNull(microsoftQIO);
            var microsoftQIOBasicSKU = microsoftQIO.Properties.Skus.FirstOrDefault((sku) => "Basic".Equals(sku.Id));
            Assert.NotNull(microsoftQIOBasicSKU);
        }
    }
}