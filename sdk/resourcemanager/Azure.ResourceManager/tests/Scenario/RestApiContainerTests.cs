using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class RestApiContainerTests : ResourceManagerTestBase
    {
        public RestApiContainerTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task ListComputeTest()
        {
            bool foundVirtualMachine = false;
            var restApiContainer = Client.GetRestApis("Microsoft.Compute");
            await foreach (var restApi in restApiContainer.GetAllAsync())
            {
                if (restApi.Resource == "Virtual Machines")
                {
                    foundVirtualMachine = true;
                    break;
                }
            }
            Assert.IsTrue(foundVirtualMachine);
        }

        [RecordedTest]
        public async Task ListNetworkTest()
        {
            bool foundPrivateEndpoint = false;
            var restApiContainer = Client.GetRestApis("Microsoft.Network");
            await foreach (var restApi in restApiContainer.GetAllAsync())
            {
                if (restApi.Resource == "Private Endpoint")
                {
                    foundPrivateEndpoint = true;
                    break;
                }
            }
            Assert.IsTrue(foundPrivateEndpoint);
        }
    }
}
