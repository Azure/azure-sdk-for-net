// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Authentication.Http.Custom;
using Azure;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Authentication.Http.Custom
{
    internal class CustomAuthTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Valid() => Test(async (host) =>
        {
            Response response = await new CustomClient(host, new AzureKeyCredential("valid-key"), null).ValidAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Invalid() => Test((host) =>
        {
            var exception = Assert.ThrowsAsync<RequestFailedException>(() => new CustomClient(host, new AzureKeyCredential("invalid-key"), null).InvalidAsync());
            Assert.That(exception!.Status, Is.EqualTo(403));
            return Task.CompletedTask;
        });
    }
}