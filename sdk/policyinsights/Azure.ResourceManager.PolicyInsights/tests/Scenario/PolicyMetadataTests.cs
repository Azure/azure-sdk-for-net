// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PolicyInsights.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.PolicyInsights.Tests
{
    internal class PolicyMetadataTests : PolicyInsightsManagementTestBase
    {
        private PolicyMetadataCollection _metadataCollection;
        public PolicyMetadataTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
            _metadataCollection = DefaultTenant.GetAllPolicyMetadata();
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var query = new PolicyQuerySettings()
            {
                Top = 3, //The restricted parameter does not work, still return 8500+ items
            };
            var list = await _metadataCollection.GetAllAsync(query).ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Get()
        {
            string metadataName = "CIS_Azure_1.3.0_7.1";
            var metadata = await _metadataCollection.GetAsync(metadataName);
            Assert.IsNotNull(metadata);
            Assert.AreEqual(metadataName, metadata.Value.Data.Name);
            Assert.AreEqual("Microsoft.PolicyInsights/policyMetadata", metadata.Value.Data.ResourceType.ToString());
            Assert.AreEqual("Shared", metadata.Value.Data.Owner);
        }

        [RecordedTest]
        public async Task GetNZISM_Security_Benchmark()
        {
            string metadataName = "NZISM_Security_Benchmark_v1.1_SS-2";
            var metadata = await _metadataCollection.GetAsync(metadataName);
            Assert.IsNotNull(metadata);
            Assert.IsNotEmpty(metadata.Value.Data.Id);
            Assert.AreEqual(metadataName, metadata.Value.Data.Name);
            Assert.AreEqual("7", metadata.Value.Data.AdditionalContentUriString);
            Assert.AreEqual(null, metadata.Value.Data.AdditionalContentUri);
        }
    }
}
