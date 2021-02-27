// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Core.Tests
{
    public class SubscriptionOperationsTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void TestGetResourceGroupOpsArgNullException(string resourceGroupName)
        {
            var client = new AzureResourceManagerClient();
            var subOps = client.DefaultSubscription;
            Assert.Throws<ArgumentOutOfRangeException>(delegate { subOps.GetResourceGroupOperations(resourceGroupName); });
        }

        [TestCase("te%st")]        
        [TestCase("test ")]
        [TestCase("te$st")]
        [TestCase("te#st")]
        [TestCase("te#st")]
        public void TestGetResourceGroupOpsArgException(string resourceGroupName)
        {
            var client = new AzureResourceManagerClient();
            var subOps = client.DefaultSubscription;
            Assert.Throws<ArgumentException>(delegate { subOps.GetResourceGroupOperations(resourceGroupName); });
        }

        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void TestGetResourceGroupOpsOutOfRangeArgException(string resourceGroupName)
        {
            var client = new AzureResourceManagerClient();
            var subOps = client.DefaultSubscription;
            Assert.Throws<ArgumentOutOfRangeException>(delegate { subOps.GetResourceGroupOperations(resourceGroupName); });
        }

        [TestCase("te.st")]
        [TestCase("te")]
        [TestCase("t")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void TestGetResourceGroupOpsValid(string resourceGroupName)
        {
            var client = new AzureResourceManagerClient();
            var subOps = client.DefaultSubscription;
            Assert.DoesNotThrow(delegate { subOps.GetResourceGroupOperations(resourceGroupName); });
        }
    }
}
