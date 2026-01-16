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
            Assert.That(pricing, Is.Not.Null);
            Assert.That(pricing.Value.Data.Name, Is.EqualTo("VirtualMachines"));
            Assert.That(pricing.Value.Data.PricingTier.ToString(), Is.EqualTo("Standard"));
            Assert.That(pricing.Value.Data.SubPlan, Is.EqualTo("P2"));
            Assert.That(pricing.Value.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.Security/pricings"));
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _pricingCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list.Exists(item => item.Data.Name == "VirtualMachines"), Is.True);
            Assert.That(list.Exists(item => item.Data.Name == "SqlServers"), Is.True);
            Assert.That(list.Exists(item => item.Data.Name == "AppServices"), Is.True);
        }
    }
}
