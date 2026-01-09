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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Invalid() => Test((host) =>
        {
            var exception = Assert.ThrowsAsync<RequestFailedException>(() => new ApiKeyClient(host, new AzureKeyCredential("invalid-key"), null).InvalidAsync());
            Assert.That(exception!.Status, Is.EqualTo(403));
            return Task.CompletedTask;
        });
    }
}
