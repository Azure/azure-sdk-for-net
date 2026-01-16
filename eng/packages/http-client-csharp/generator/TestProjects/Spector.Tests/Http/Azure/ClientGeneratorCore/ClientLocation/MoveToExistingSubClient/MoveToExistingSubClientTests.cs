
using NUnit.Framework;
using System.Threading.Tasks;
using MoveToExistingSubClientClass = Specs.Azure.ClientGenerator.Core.ClientLocation._MoveToExistingSubClient.MoveToExistingSubClient;
using MoveToExistingSubClientOptions = Specs.Azure.ClientGenerator.Core.ClientLocation._MoveToExistingSubClient.MoveToExistingSubClientOptions;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientLocation.MoveToExistingSubClient
{
    public class MoveToExistingSubClientTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientLocation_MoveToExistingSubClient() => Test(async (host) =>
        {
            var response1 = await new MoveToExistingSubClientClass(host, new MoveToExistingSubClientOptions()).GetUserOperationsClient().GetUserAsync();
            Assert.That(response1.Status, Is.EqualTo(204));

            var response2 = await new MoveToExistingSubClientClass(host, new MoveToExistingSubClientOptions()).GetAdminOperationsClient().DeleteUserAsync();
            Assert.That(response2.Status, Is.EqualTo(204));

            var response3 = await new MoveToExistingSubClientClass(host, new MoveToExistingSubClientOptions()).GetAdminOperationsClient().GetAdminInfoAsync();
            Assert.That(response3.Status, Is.EqualTo(204));
        });
    }
}
