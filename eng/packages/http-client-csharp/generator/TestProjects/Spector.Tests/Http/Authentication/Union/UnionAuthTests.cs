// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Authentication.Union;
using Azure;
using Azure.Core;
using CadlRanchProjects.Tests;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Authentication.Union
{
    public class AuthenticationUnionTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Authentication_Union_validKey() => Test(async (host) =>
        {
            Response response = await new UnionClient(host, new AzureKeyCredential("valid-key"), null).ValidKeyAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Authentication_Union_validToken() => Test(async (host) =>
        {
            var options = new UnionClientOptions();
            options.AddPolicy(new OAuth2TestHelper.MockBearerTokenAuthenticationPolicy(new OAuth2TestHelper.MockCredential(), new string[] { "https://security.microsoft.com/.default" }, options.Transport), HttpPipelinePosition.PerCall);
            Response response = await new UnionClient(host, new OAuth2TestHelper.MockCredential(), options).ValidTokenAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}