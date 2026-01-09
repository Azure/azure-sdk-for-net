// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Threading.Tasks;
using Specs.Azure.ClientGenerator.Core.ClientLocation;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientLocation
{
    public class ClientLocationTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientLocation_MoveToExistingSubClient() => Test(async (host) =>
        {
            var response1 = await new ClientLocationClient(host, "testaccount", null).GetMoveToExistingSubClient().GetMoveToExistingSubClientUserOperationsClient().GetUserAsync();
            Assert.That(response1.Status, Is.EqualTo(204));

            var response2 = await new ClientLocationClient(host, "testaccount", null).GetMoveToExistingSubClient().GetMoveToExistingSubClientAdminOperationsClient().DeleteUserAsync();
            Assert.That(response2.Status, Is.EqualTo(204));

            var response3 = await new ClientLocationClient(host, "testaccount", null).GetMoveToExistingSubClient().GetMoveToExistingSubClientAdminOperationsClient().GetAdminInfoAsync();
            Assert.That(response3.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientLocation_MoveToNewSubClient() => Test(async (host) =>
        {
            var response1 = await new ClientLocationClient(host, "testaccount", null).GetMoveToNewSubClient().GetMoveToNewSubClientProductOperationsClient().GetProductsAsync();
            Assert.That(response1.Status, Is.EqualTo(204));

            var response2 = await new ClientLocationClient(host, "testaccount", null).GetArchiveOperationsClient().ArchiveProductAsync();
            Assert.That(response2.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientLocation_MoveToRootClient() => Test(async (host) =>
        {
            var response1 = await new ClientLocationClient(host, "testaccount", null).GetMoveToRootClient().GetMoveToRootClientResourceOperationsClient().GetResourceAsync();
            Assert.That(response1.Status, Is.EqualTo(204));

            var response2 = await new ClientLocationClient(host, "testaccount", null).GetHealthStatusAsync();
            Assert.That(response2.Status, Is.EqualTo(204));
        });
    }
}