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
            Assert.AreEqual(AzureLocation.EastUS, response.Value);
        });

        [SpectorTest]
        public Task Azure_Core_Scalar_AzureLocation_put() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().PutAsync(new AzureLocation("eastus"));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Azure_Core_Scalar_AzureLocation_post() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().PostAsync(new AzureLocationModel(new AzureLocation("eastus")));
            Assert.AreEqual(AzureLocation.EastUS, response.Value.Location);
        });

        [SpectorTest]
        public Task Azure_Core_Scalar_AzureLocation_header() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().HeaderAsync(AzureLocation.EastUS);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Azure_Core_Scalar_AzureLocation_query() => Test(async (host) =>
        {
            var response = await new ScalarClient(host, null).GetAzureLocationScalarClient().QueryAsync(AzureLocation.EastUS);
            Assert.AreEqual(204, response.Status);
        });
    }
}