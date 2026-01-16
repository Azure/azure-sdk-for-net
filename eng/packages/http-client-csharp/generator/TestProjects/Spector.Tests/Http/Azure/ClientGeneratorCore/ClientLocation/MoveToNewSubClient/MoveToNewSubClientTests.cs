
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
            Assert.That(response1.Status, Is.EqualTo(204));

            var response2 = await new MoveToNewSubClientClass(host, new MoveToNewSubClientOptions()).GetArchiveOperationsClient().ArchiveProductAsync();
            Assert.That(response2.Status, Is.EqualTo(204));
        });
    }
}
