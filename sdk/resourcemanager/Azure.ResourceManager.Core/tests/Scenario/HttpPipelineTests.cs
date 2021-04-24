using System;
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

        public HttpPipelineTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _client = GetArmClient();
        }

        [Test]
        public async Task ValidateHttpPipelines()
        {
            await _client.DefaultSubscription
                .GetResourceGroups().Construct("westus")
                .CreateOrUpdateAsync("test-CacheHttpPipeline");
            await foreach (var rg in _client.DefaultSubscription.GetResourceGroups().ListAsync())
            {
                Assert.AreEqual(rg.Pipeline.GetHashCode(), _client.DefaultSubscription.Pipeline.GetHashCode());
            }
        }
    }
}
