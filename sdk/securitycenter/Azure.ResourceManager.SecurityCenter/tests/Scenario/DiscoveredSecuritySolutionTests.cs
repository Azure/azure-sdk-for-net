// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class DiscoveredSecuritySolutionTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public DiscoveredSecuritySolutionTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
        }

        [RecordedTest]
        [Ignore("Have not exist discoveredSecuritySolution")]
        public async Task Get()
        {
            string ascLocation = "";
            string discoveredSecuritySolutionName = "";
            var discoveredSecuritySolution = await _resourceGroup.GetDiscoveredSecuritySolutionAsync(ascLocation, discoveredSecuritySolutionName);
            Assert.IsNotNull(discoveredSecuritySolution);
        }

        [RecordedTest]
        public async Task List()
        {
            var list = await DefaultSubscription.GetDiscoveredSecuritySolutionsAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }

        [RecordedTest]
        public async Task ListByHomeRegion()
        {
            var ascLocation = await DefaultSubscription.GetSecurityCenterLocations().GetAsync("centralus");
            var list = await ascLocation.Value.GetDiscoveredSecuritySolutionsByHomeRegionAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
