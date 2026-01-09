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
        [Ignore("Service return wrong uri")]
        public async Task GetAll()
        {
            var query = new PolicyQuerySettings()
            {
                Top = 3, //The restricted parameter does not work, still return 8500+ items
            };
            var list = await _metadataCollection.GetAllAsync(query).ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Get()
        {
            string metadataName = "CIS_Azure_1.3.0_7.1";
            var metadata = await _metadataCollection.GetAsync(metadataName);
            Assert.That(metadata, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(metadata.Value.Data.Name, Is.EqualTo(metadataName));
                Assert.That(metadata.Value.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.PolicyInsights/policyMetadata"));
                Assert.That(metadata.Value.Data.Owner, Is.EqualTo("Shared"));
                Assert.That(metadata.Value.Data.AdditionalContentUri, Is.Not.Null);
            });
        }

        [RecordedTest]
        [Ignore("Service return wrong uri")]
        public async Task GetNZISM_Security_Benchmark()
        {
            string metadataName = "NZISM_Security_Benchmark_v1.1_SS-2";
            var metadata = await _metadataCollection.GetAsync(metadataName);
            Assert.Multiple(() =>
            {
                Assert.That(metadata, Is.Not.Null);
                Assert.That((string)metadata.Value.Data.Id, Is.Not.Empty);
            });
            Assert.That(metadata.Value.Data.Name, Is.EqualTo(metadataName));
            Assert.That(metadata.Value.Data.AdditionalContentUri, Is.EqualTo("7"));
        }
    }
}
