// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Authentication.ApiKey;
using Azure;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TestProjects.Spector.Tests.Http.Authentication.ApiKey
{
    public class ApiKeyTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Valid() => Test(async (host) =>
        {
            Response response = await new ApiKeyClient(host, new AzureKeyCredential("valid-key"), null).ValidAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Invalid() => Test((host) =>
        {
            var exception = Assert.ThrowsAsync<RequestFailedException>(() => new ApiKeyClient(host, new AzureKeyCredential("invalid-key"), null).InvalidAsync());
            Assert.AreEqual(403, exception!.Status);
            return Task.CompletedTask;
        });
    }
}
