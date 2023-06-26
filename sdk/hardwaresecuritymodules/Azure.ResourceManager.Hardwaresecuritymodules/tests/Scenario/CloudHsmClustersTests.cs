using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Hardwaresecuritymodules.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.ResourceManager.Hardwaresecuritymodules.Tests
{
    public class CloudHsmClustersTests : HardwaresecuritymodulesManagementTestBase
    {
        public CloudHsmClustersTests(bool isAsync)
        : base(isAsync)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUpForTests();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateCloudHsmClusterTest()
        {
            
        }
    }
}
