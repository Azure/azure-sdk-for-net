// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Threading.Tasks;
using Authentication.ApiKey;
using NUnit.Framework;

namespace TestProjects.CadlRanch.Tests.Http.Authentication.ApiKey
{
    public class ApiKeyTests : CadlRanchTestBase
    {
        [CadlRanchTest]
        public Task Valid() => Test(async (host) =>
        {
            ClientResult response = await new ApiKeyClient(host, new ApiKeyCredential("valid-key"), null).ValidAsync();
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [CadlRanchTest]
        public Task Invalid() => Test((host) =>
        {
            var exception = Assert.ThrowsAsync<ClientResultException>(() => new ApiKeyClient(host, new ApiKeyCredential("invalid-key"), null).InvalidAsync());
            Assert.AreEqual(403, exception!.Status);
            return Task.CompletedTask;
        });
    }
}
