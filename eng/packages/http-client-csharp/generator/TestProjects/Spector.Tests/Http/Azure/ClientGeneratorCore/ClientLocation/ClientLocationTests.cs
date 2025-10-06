// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Threading.Tasks;
using _Specs_.Azure.ClientGenerator.Core.ClientLocation;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientLocation
{
    public class ClientLocationTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientLocation_MoveToExistingSubClient() => Test(async (host) =>
        {
            var response1 = await new ClientLocationClient(host, null).GetMoveToExistingSubClient().GetMoveToExistingSubClientUserOperationsClient().GetUserAsync();
            Assert.AreEqual(204, response1.Status);

            var response2 = await new ClientLocationClient(host, null).GetMoveToExistingSubClient().GetMoveToExistingSubClientAdminOperationsClient().DeleteUserAsync();
            Assert.AreEqual(204, response2.Status);

            var response3 = await new ClientLocationClient(host, null).GetMoveToExistingSubClient().GetMoveToExistingSubClientAdminOperationsClient().GetAdminInfoAsync();
            Assert.AreEqual(204, response3.Status);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientLocation_MoveToNewSubClient() => Test(async (host) =>
        {
            var response1 = await new ClientLocationClient(host, null).GetMoveToNewSubClient().GetMoveToNewSubClientProductOperationsClient().GetProductsAsync();
            Assert.AreEqual(204, response1.Status);

            var response2 = await new ClientLocationClient(host, null).GetArchiveOperationsClient().ArchiveProductAsync();
            Assert.AreEqual(204, response2.Status);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientLocation_MoveToRootClient() => Test(async (host) =>
        {
            var response1 = await new ClientLocationClient(host, null).GetMoveToRootClient().GetMoveToRootClientResourceOperationsClient().GetResourceAsync();
            Assert.AreEqual(204, response1.Status);

            var response2 = await new ClientLocationClient(host, null).GetHealthStatusAsync();
            Assert.AreEqual(204, response2.Status);
        });
    }
}