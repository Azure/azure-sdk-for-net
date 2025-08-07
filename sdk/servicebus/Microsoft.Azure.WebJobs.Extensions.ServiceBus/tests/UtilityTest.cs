// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    internal class UtilityTest
    {
        [Test]
        public void GetProcessorCount_ReturnsOneForDynamicAndFlexSkus()
        {
            Environment.SetEnvironmentVariable(Constants.AzureWebsiteSku, Constants.DynamicSku);
            Assert.AreEqual(1, Utility.GetProcessorCount());

            Environment.SetEnvironmentVariable(Constants.AzureWebsiteSku, Constants.FlexConsumptionSku);
            Assert.AreEqual(1, Utility.GetProcessorCount());
        }
    }
}
