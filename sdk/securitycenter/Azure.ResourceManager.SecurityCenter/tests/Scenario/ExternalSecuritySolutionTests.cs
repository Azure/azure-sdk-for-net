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
    internal class ExternalSecuritySolutionTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ExternalSecuritySolutionCollection _externalSecuritySolutionCollection;

        public ExternalSecuritySolutionTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _externalSecuritySolutionCollection = _resourceGroup.GetExternalSecuritySolutions();
        }

        [RecordedTest]
        [Ignore("Have not exist externalSecuritySolutions")]
        public async Task Get()
        {
            string ascLocation = "";
            string externalSecuritySolutionsName = "";
            var externalSecuritySolutions = await _externalSecuritySolutionCollection.GetAsync(ascLocation, externalSecuritySolutionsName);
            Assert.IsNotNull(externalSecuritySolutions);
        }

        [RecordedTest]
        public async Task List()
        {
            var list = await DefaultSubscription.GetExternalSecuritySolutionsByExternalSecuritySolutionAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }

        [RecordedTest]
        public async Task ListByHomeRegion()
        {
            var ascLocation = await DefaultSubscription.GetAscLocations().GetAsync("centralus");
            var list = await ascLocation.Value.GetExternalSecuritySolutionsByHomeRegionAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
