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
        public void ValidateHttpPipelines()
        {
            ResourceGroup resourceGroup = _client.DefaultSubscription
                .GetResourceGroups().Construct("westus")
                .CreateOrUpdateAsync("test-CacheHttpPipeline").ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.AreEqual(resourceGroup.Pipeline.GetHashCode(), _client.DefaultSubscription.Pipeline.GetHashCode());
        }
    }
}
