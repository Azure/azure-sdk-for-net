
using NUnit.Framework;
using MoveToNewSubClientClass = Specs.Azure.ClientGenerator.Core.ClientLocation._MoveToNewSubClient.MoveToNewSubClient;
using MoveToNewSubClientOptions = Specs.Azure.ClientGenerator.Core.ClientLocation._MoveToNewSubClient.MoveToNewSubClientOptions;
using System.Threading.Tasks;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientLocation.MoveToNewSubClient
{
    public class MoveToNewSubClientTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientLocation_MoveToNewSubClient() => Test(async (host) =>
        {
            var response1 = await new MoveToNewSubClientClass(host, new MoveToNewSubClientOptions()).GetProductOperationsClient().GetProductsAsync();
            Assert.AreEqual(204, response1.Status);

            var response2 = await new MoveToNewSubClientClass(host, new MoveToNewSubClientOptions()).GetArchiveOperationsClient().ArchiveProductAsync();
            Assert.AreEqual(204, response2.Status);
        });
    }
}
