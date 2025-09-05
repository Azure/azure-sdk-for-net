// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using NUnit.Framework;
using System.Threading.Tasks;
using Authentication.OAuth2;
using Azure.Core;
using static CadlRanchProjects.Tests.OAuth2TestHelper;

namespace TestProjects.Spector.Tests.Http.Authentication.Oauth2
{
    public class OAuthTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Valid() => Test(async (host) =>
        {
            var options = new OAuth2ClientOptions();
            options.AddPolicy(new MockBearerTokenAuthenticationPolicy(new MockCredential(),  new string[] { "https://security.microsoft.com/.default" }, options.Transport), HttpPipelinePosition.PerCall);
            Response response = await new OAuth2Client(host, new MockCredential(), options).ValidAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Invalid() => Test((host) =>
        {
            var options = new OAuth2ClientOptions();
            options.AddPolicy(new MockBearerTokenAuthenticationPolicy(new MockCredential(),  new string[] { "https://security.microsoft.com/.default" }, options.Transport), HttpPipelinePosition.PerCall);

            var exception = Assert.ThrowsAsync<RequestFailedException>(() => new OAuth2Client(host, new MockCredential(), options).InvalidAsync());
            Assert.AreEqual(403, exception!.Status);
            return Task.CompletedTask;
        });
    }
}
