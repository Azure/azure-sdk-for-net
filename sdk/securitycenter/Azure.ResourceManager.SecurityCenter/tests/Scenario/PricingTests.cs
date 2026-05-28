// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;
using NUnit.Framework.Internal.Builders;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class PricingTests : SecurityCenterManagementTestBase
    {
        private SecurityCenterPricingCollection _pricingCollection;
        public PricingTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
            _pricingCollection = DefaultSubscription.GetSecurityCenterPricings();
        }

        [RecordedTest]
        public async Task Get()
        {
            var pricing = await _pricingCollection.GetAsync("VirtualMachines");
            Assert.IsNotNull(pricing);
            Assert.AreEqual("VirtualMachines", pricing.Value.Data.Name);
            Assert.AreEqual("Standard", pricing.Value.Data.PricingTier.ToString());
            Assert.AreEqual("P2",pricing.Value.Data.SubPlan);
            Assert.AreEqual("Microsoft.Security/pricings", pricing.Value.Data.ResourceType.ToString());
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _pricingCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Exists(item => item.Data.Name == "VirtualMachines"));
            Assert.IsTrue(list.Exists(item => item.Data.Name == "SqlServers"));
            Assert.IsTrue(list.Exists(item => item.Data.Name == "AppServices"));
        }
    }
}
