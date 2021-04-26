﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests.Scenario
{
    [Parallelizable]
    public class HttpPipelineTests : ResourceManagerTestBase
    {
        private ArmClient _client;
        private string _rgName;

        public HttpPipelineTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _client = GetArmClient();
            _rgName = Recording.GenerateAssetName("test-CacheHttpPipeline");
        }

        [Test]
        [RecordedTest]
        public async Task ValidateHttpPipelines()
        {
            await _client.DefaultSubscription
                .GetResourceGroups().Construct("westus")
                .CreateOrUpdateAsync(_rgName);
            await foreach (var rg in _client.DefaultSubscription.GetResourceGroups().ListAsync())
            {
                Assert.AreEqual(rg.Pipeline.GetHashCode(), _client.DefaultSubscription.Pipeline.GetHashCode());
            }
        }
    }
}
