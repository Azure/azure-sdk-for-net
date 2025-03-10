// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentitySourceTests : ClientTestBase
    {
        public ManagedIdentitySourceTests(bool isAsync) : base(isAsync)
        {
        }

        public static IEnumerable<object[]> ManagedIdentitySources()
        {
            var mockTransport = new MockTransport(request => CreateMockResponse(200, "secret", (int)TimeSpan.FromHours(24).TotalSeconds).WithHeader("Content-Type", "application/json"));
            var options = new TokenCredentialOptions() { Transport = mockTransport };
            options.Retry.MaxDelay = TimeSpan.Zero;
            var pipeline = CredentialPipeline.GetInstance(options);
            var mockClient = new MockManagedIdentityClient(pipeline)
            {
                TokenFactory = () => { return new AccessToken("secret", DateTimeOffset.UtcNow.AddHours(24)); }
            };
            var miCredOptions = new ManagedIdentityClientOptions { Pipeline = pipeline };
            var endpoint = new Uri("https://localhost");

            yield return new object[] { new ImdsManagedIdentityProbeSource(new ManagedIdentityClientOptions { Pipeline = pipeline, ManagedIdentityId = ManagedIdentityId.FromUserAssignedClientId("mock-client-id") }, new MockMsalManagedIdentityClient()) };
        }

        [Test]
        [TestCaseSource(nameof(ManagedIdentitySources))]
        public void VerifyAuthenticateDoesNotLogTokenOnTaskCancelled(object miSource)
        {
            var source = (ManagedIdentitySource)miSource;
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await source.AuthenticateAsync(IsAsync, new TokenRequestContext(MockScopes.Default), new CancellationToken(true)));
            Assert.IsInstanceOf(typeof(TaskCanceledException), ex.InnerException);
            Assert.That(ex.Message, Does.Not.Contain("secret"));
            Assert.That(ex.Message, Does.Contain("Response from Managed Identity was successful, but the operation timed out prior to completion."));
        }

        [Test]
        [TestCaseSource(nameof(ManagedIdentitySources))]
        public async Task RefreshOnPopulatedWhenTokenExpirationGreaterThanTwoHours(object miSource)
        {
            var source = (ManagedIdentitySource)miSource;
            var token = await source.AuthenticateAsync(IsAsync, new TokenRequestContext(MockScopes.Default), CancellationToken.None);
            Assert.IsNotNull(token.RefreshOn);
        }

        private static MockResponse CreateMockResponse(int responseCode, string token, int expiresInSeconds = 3600)
        {
            var expireOn = DateTimeOffset.UtcNow.AddSeconds(expiresInSeconds).ToUnixTimeSeconds();
            var response = new MockResponse(responseCode);
            string jsonData = $"{{ \"access_token\": \"{token}\", \"expires_on\": \"{expireOn}\" }}";
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
            response.ContentStream = new MemoryStream(byteArray);
            return response;
        }
    }
}
