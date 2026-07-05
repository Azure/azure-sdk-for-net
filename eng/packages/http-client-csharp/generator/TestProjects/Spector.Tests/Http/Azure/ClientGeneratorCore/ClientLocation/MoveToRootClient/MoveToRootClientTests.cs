using NUnit.Framework;
using System.Threading.Tasks;
using MoveToRootClientClass = Specs.Azure.ClientGenerator.Core.ClientLocation._MoveToRootClient.MoveToRootClient;
using MoveToRootClientOptions = Specs.Azure.ClientGenerator.Core.ClientLocation._MoveToRootClient.MoveToRootClientOptions;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientLocation.MoveToRootClient
{
    public class MoveToRootClientTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientLocation_MoveToRootClient() => Test(async (host) =>
        {
            var response1 = await new MoveToRootClientClass(host, new MoveToRootClientOptions()).GetResourceOperationsClient().GetResourceAsync();
            Assert.AreEqual(204, response1.Status);

            var response2 = await new MoveToRootClientClass(host, new MoveToRootClientOptions()).GetHealthStatusAsync();
            Assert.AreEqual(204, response2.Status);
        });
    }
}
