// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Specs.Azure.Core.Scalar;
using Azure.Core;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.Core.Scalar
{
    public class AzureCoreScalarTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_Core_Scalar_AzureLocation_get() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().GetAsync();
            Assert.That(response.Value, Is.EqualTo(AzureLocation.EastUS));
        });

        [SpectorTest]
        public Task Azure_Core_Scalar_AzureLocation_put() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().PutAsync(new AzureLocation("eastus"));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Azure_Core_Scalar_AzureLocation_post() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().PostAsync(new AzureLocationModel(new AzureLocation("eastus")));
            Assert.That(response.Value.Location, Is.EqualTo(AzureLocation.EastUS));
        });

        [SpectorTest]
        public Task Azure_Core_Scalar_AzureLocation_header() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().HeaderAsync(AzureLocation.EastUS);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Azure_Core_Scalar_AzureLocation_query() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().QueryAsync(AzureLocation.EastUS);
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}